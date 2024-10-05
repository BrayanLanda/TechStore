using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.DTOs.OrderDtos
{
    public class OrderStatusUpdateDto
    {
        [Required(ErrorMessage = "Order ID is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order status is required")]
        public string Status { get; set; }  // Example: "Pending", "Shipped", "Delivered"
    }
}