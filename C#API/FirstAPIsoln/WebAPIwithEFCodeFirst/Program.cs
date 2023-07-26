global using WebAPIwithEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPIwithEFCodeFirst.Data;
using WebAPIwithEFCodeFirst.Services.StudentService;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddDbContext<StudentDataContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString(name : "SQLConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("StudentCorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
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
app.UseCors("StudentCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
