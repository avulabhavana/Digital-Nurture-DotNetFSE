using Microsoft.EntityFrameworkCore;
using RetailStoreApp.Data;
using RetailStoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();

    // Insert sample data
    if (!context.Categories.Any())
    {
        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        context.Categories.AddRange(electronics, groceries);

        context.Products.AddRange(
            new Product
            {
                Name = "Laptop",
                Price = 70000,
                Category = electronics
            },
            new Product
            {
                Name = "Rice Bag",
                Price = 1200,
                Category = groceries
            },
            new Product
            {
                Name = "Mobile",
                Price = 25000,
                Category = electronics
            });

        context.SaveChanges();
    }

    Console.WriteLine("Filtered and Sorted Products");

    var filtered = await context.Products
        .Where(p => p.Price > 1000)
        .OrderByDescending(p => p.Price)
        .ToListAsync();

    foreach (var product in filtered)
    {
        Console.WriteLine($"{product.Name} - ₹{product.Price}");
    }

    Console.WriteLine("\nProjected DTO");

    var productDTOs = await context.Products
        .Select(p => new
        {
            p.Name,
            p.Price
        })
        .ToListAsync();

    foreach (var dto in productDTOs)
    {
        Console.WriteLine($"{dto.Name} - ₹{dto.Price}");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();