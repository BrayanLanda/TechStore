using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.OrderDtos
{
    public class OrderDto
    {
        [Required(ErrorMessage = "Customer ID is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "At least one product is required")]
        public List<OrderItemDto> OrderItems { get; set; }

        [Required(ErrorMessage = "Order status is required")]
        public string Status { get; set; }  // Example: "Pending", "Shipped", "Delivered"

        [Required(ErrorMessage = "Order creation date is required")]
        public DateTime CreationDate { get; set; }
    }
}