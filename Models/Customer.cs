namespace TechStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Relationship: Each customer can have multiple orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}