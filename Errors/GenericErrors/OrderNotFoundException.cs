using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // OrderNotFoundException.cs
    public class OrderNotFoundException : BaseException
    {
        public OrderNotFoundException(int orderId)
            : base($"Order with id {orderId} was not found.", StatusCodes.Status404NotFound)
        {
        }
    }
}