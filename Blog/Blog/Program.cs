using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddMvc();

var app = builder.Build();
app.MapControllers();

app.Run();
