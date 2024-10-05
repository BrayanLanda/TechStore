using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // InvalidOrderStatusException.cs
    public class InvalidOrderStatusException : BaseException
    {
        public InvalidOrderStatusException(string status)
            : base($"Order status '{status}' is not valid.", StatusCodes.Status400BadRequest)
        {
        }
    }
}