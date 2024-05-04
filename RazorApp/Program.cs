using Domain.Entities;
using Infrastructure.AutoMapper;
using Infrastructure.Data;
using Infrastructure.Services.CategoryService;
using Infrastructure.Services.MarketService;
using Infrastructure.Services.ProductService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(x=>x.UseNpgsql(connection));

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IMarketService, MarketService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));
// Add services to the container.
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();