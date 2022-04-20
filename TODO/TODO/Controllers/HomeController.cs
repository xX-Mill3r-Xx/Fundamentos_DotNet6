﻿using Microsoft.AspNetCore.Mvc;
using TODO.Data;
using TODO.Models;

namespace TODO.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region Metodo Get
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.Todos.ToList());
        #endregion

        #region Metodo GetById
        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id,[FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);
            if(todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
        #endregion

        #region Metodo Post
        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return Created($"/{todo.Id}",todo);
        }
        #endregion

        #region Metodo Post
        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }
        #endregion

        #region Metodo Delete
        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
        #endregion
    }
}
