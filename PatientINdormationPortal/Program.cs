using Microsoft.EntityFrameworkCore;
using PatientInformationPortalAPI.Interface;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Repository;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Datbase ConnectionString
builder.Services.AddDbContext<PatientInformationPortalDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// Adding the Unit of work to the DI container
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

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
