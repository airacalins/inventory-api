using Application.Commands.Companies;
using Application.Commands.Companies.Interfaces;
using Application.Commands.Products;
using Application.Commands.Products.Interfaces;
using Application.Contexts;
using Application.Repositories.CompanyRepositories;
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
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

// Dependency Injection
builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

// Dependency Injection - Commands
builder.Services.AddScoped<ICreateProductCommand, CreateProductCommand>();
builder.Services.AddScoped<IGetProductsCommand, GetProductsCommand>();
builder.Services.AddScoped<IGetProductByIdCommand, GetProductByIdCommand>();
builder.Services.AddScoped<IUpdateProductCommand, UpdateProductCommand>();
builder.Services.AddScoped<IDeleteProductCommand, DeleteProductCommand>();

builder.Services.AddScoped<ICreateCompanyCommand, CreateCompanyCommand>();
builder.Services.AddScoped<IGetCompaniesCommand, GetCompaniesCommand>();
builder.Services.AddScoped<IGetCompanyByIdCommand, GetCompanyByIdCommand>();
builder.Services.AddScoped<IUpdateCompanyCommand, UpdateCompanyCommand>();
builder.Services.AddScoped<IDeleteCompanyCommand, DeleteCompanyCommand>();

// Dependency Injection - Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
