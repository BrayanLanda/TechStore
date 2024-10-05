using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // OrderAlreadyShippedException.cs
    public class OrderAlreadyShippedException : BaseException
    {
        public OrderAlreadyShippedException(int orderId)
            : base($"Order with id {orderId} has already been shipped.", StatusCodes.Status400BadRequest)
        {
        }
    }
}