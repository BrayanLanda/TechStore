namespace TechStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        // Relationship: Each order item refers to one product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Relationship: Each order item refers to one order
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; } // Stores the price at the time of order
    }
}