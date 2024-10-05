namespace TechStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relationship: Each category can have multiple products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}