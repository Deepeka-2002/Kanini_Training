//using EbookAPI.Models;
using EbookAPI.Models;
using EbookAPI.Repository.Book_borrow_masterServices;
using EbookAPI.Repository.BookBorrowsServices;
using EbookAPI.Repository.BooksServices;
using EbookAPI.Repository.CategoriesServices;
using EbookAPI.Repository.SubscriptiondetailsServices;
using EbookAPI.Repository.UsersServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBook_borrow_masterServices, Book_borrow_masterServices>();
builder.Services.AddScoped<IBookBorrowsServices, BookBorrowsServices>();
builder.Services.AddScoped<IBooksServices,BooksServices>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
builder.Services.AddScoped<ISubscriptiondetailsServices, SubscriptiondetailsServices>();
builder.Services.AddScoped<IUsersServices,UsersServices>();


builder.Services.AddDbContext<EbookContext>(optionsAction: options =>
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
