using Application.Commands;
using Application.Commands.Products;
using Application.Commands.Products.Interfaces;
using Application.Contexts;
using Application.Repositories.ProductRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Dependency Injection
builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

// Dependency Injection - Commands
builder.Services.AddScoped<ICreateProductCommand, CreateProductCommand>();
builder.Services.AddScoped<IGetProductsCommand, GetProductsCommand>();
builder.Services.AddScoped<IGetProductByIdCommand, GetProductByIdCommand>();
builder.Services.AddScoped<IUpdateProductCommand, UpdateProductCommand>();

// Dependency Injection - Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
