using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;

using Rel2.Models;
using Rel2.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryInterface, EmpService>();
builder.Services.AddScoped<IRepositoryInterface, DeptService>();

builder.Services.AddDbContext<CompanyContextCF>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString(name: "SQLConnection")));

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
