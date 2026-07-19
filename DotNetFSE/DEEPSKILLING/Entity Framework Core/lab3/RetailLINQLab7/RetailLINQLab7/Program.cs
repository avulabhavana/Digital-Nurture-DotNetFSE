using Microsoft.EntityFrameworkCore;
using RetailLINQLab7;

using var context = new AppDbContext();

// Insert sample data only once
if (!context.Products.Any())
{
    var electronics = new Category { Name = "Electronics" };

    await context.Categories.AddAsync(electronics);

    await context.Products.AddRangeAsync(
        new Product
        {
            Name = "Laptop",
            Price = 75000,
            Category = electronics
        },
        new Product
        {
            Name = "Mouse",
            Price = 1500,
            Category = electronics
        },
        new Product
        {
            Name = "Keyboard",
            Price = 800,
            Category = electronics
        });

    await context.SaveChangesAsync();
}

// Filter and Sort
Console.WriteLine("Products with Price > 1000");

var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

foreach (var p in filtered)
{
    Console.WriteLine($"{p.Name} - ₹{p.Price}");
}

// DTO Projection
Console.WriteLine("\nProduct DTOs");

var productDTOs = await context.Products
    .Select(p => new
    {
        p.Name,
        p.Price
    })
    .ToListAsync();

foreach (var p in productDTOs)
{
    Console.WriteLine($"{p.Name} - ₹{p.Price}");
}