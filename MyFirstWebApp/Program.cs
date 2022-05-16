using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Model;
using MyFirstWebApp.Repositories;
using MyFirstWebApp.Service;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<BooksRepository>();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BooksContext>(x => x.UseSqlServer(connectionString));

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
app.MapControllers();

app.MapGet("/products", (context) =>
{
    var products = app.Services.GetService<ProductService>().GetProducts();
    var json = JsonSerializer.Serialize<Product[]>(products);
    return context.Response.WriteAsync(json);
}
);

app.Run();
