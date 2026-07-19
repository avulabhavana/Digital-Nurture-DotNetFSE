using System.Collections.Generic;

namespace RetailUpdateDeleteLab6
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new();
    }
}