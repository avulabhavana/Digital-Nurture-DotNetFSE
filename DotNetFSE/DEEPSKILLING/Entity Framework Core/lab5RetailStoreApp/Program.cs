using Microsoft.EntityFrameworkCore;
using RetailStoreApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Retrieve data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Insert data if database is empty
    if (!context.Categories.Any())
    {
        var electronics = new RetailStoreApp.Models.Category { Name = "Electronics" };
        var groceries = new RetailStoreApp.Models.Category { Name = "Groceries" };

        context.Categories.AddRange(electronics, groceries);

        context.Products.AddRange(
            new RetailStoreApp.Models.Product
            {
                Name = "Laptop",
                Price = 75000,
                Category = electronics
            },
            new RetailStoreApp.Models.Product
            {
                Name = "Rice Bag",
                Price = 1200,
                Category = groceries
            });

        context.SaveChanges();
    }

    // Retrieve all products
    var products = await context.Products.ToListAsync();

    Console.WriteLine("All Products");
    foreach (var p in products)
        Console.WriteLine($"{p.Name} - ₹{p.Price}");

    // Find by ID
    var product = await context.Products.FindAsync(1);
    Console.WriteLine($"\nFound: {product?.Name}");

    // FirstOrDefault
    var expensive = await context.Products
        .FirstOrDefaultAsync(p => p.Price > 50000);

    Console.WriteLine($"Expensive Product: {expensive?.Name}");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();