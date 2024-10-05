namespace TechStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Relationship: Each product belongs to one category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}