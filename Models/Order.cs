namespace TechStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }  // pending, shipped, delivered

        // Relationship: Each order is linked to one customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Relationship: An order can contain multiple products
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}