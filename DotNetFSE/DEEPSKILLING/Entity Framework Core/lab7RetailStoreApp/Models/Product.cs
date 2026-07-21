using System.ComponentModel.DataAnnotations;

namespace RetailStoreApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}