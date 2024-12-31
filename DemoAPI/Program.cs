using Demo.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

