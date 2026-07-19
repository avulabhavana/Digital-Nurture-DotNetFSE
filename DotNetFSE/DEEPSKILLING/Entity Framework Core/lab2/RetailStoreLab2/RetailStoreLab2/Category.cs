using System.Collections.Generic;

namespace RetailStoreLab2
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new();
    }
}