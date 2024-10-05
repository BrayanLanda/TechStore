using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // CustomerAlreadyExistsException.cs
    public class CustomerAlreadyExistsException : BaseException
    {
        public CustomerAlreadyExistsException(string email)
            : base($"Customer with email {email} already exists.", StatusCodes.Status400BadRequest)
        {
        }
    }
}