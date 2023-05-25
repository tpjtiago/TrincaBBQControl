using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TrincaBBQControl.API.Configuration;
using TrincaBBQControl.Data.Contexts;
using TrincaBBQControl.Domain.Entities;
using TrincaBBQControl.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TrincaBBQContext>(x => x.UseSqlServer(connectionString));

DependencyInjectionConfiguration.DependencyInjection(builder);

AutoMapperConfiguration.AddAutoMapper(builder);

builder.Services.AddTransient<IValidator<Barbecue>, BarbecueValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
