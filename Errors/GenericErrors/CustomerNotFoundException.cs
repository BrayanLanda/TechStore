using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    public class CustomerNotFoundException : BaseException
    {
        public CustomerNotFoundException(int customerId)
            : base($"Customer with id {customerId} was not found.", StatusCodes.Status404NotFound)
        {
        }
    }
}