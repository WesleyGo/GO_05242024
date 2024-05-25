using API.Application;
using API.Domain.Interface;
using API.Domain.Models;
using API.Endpoints;
using API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices()
    .AddInfrastructureServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "http://localhost:16000").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseMiddleware<APIKeyAuthenticationMiddleware>();

        
app.MapGet("/api/items", (IItemLogic _logic) =>
{
   return _logic.GetAllItems();
})
.WithName("GetItems")
.WithOpenApi();

app.MapGet("/api/items/{id}", (int id, IItemLogic _logic) =>
{
    return _logic.GetItemById(id);
})
.WithName("GetItemById")
.WithOpenApi();

app.MapPut("/api/items/{id}", (int id, Item item, IItemLogic _logic) =>
{
    _logic.UpdateItem(item);
})
.WithName("UpdateItemById")
.WithOpenApi();

app.MapPost("/api/items", (Item item, IItemLogic _logic) =>
{
    _logic.AddItem(item);
})
.WithName("AddItem")
.WithOpenApi();

app.Run();
