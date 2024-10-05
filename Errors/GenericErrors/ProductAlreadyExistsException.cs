using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    public class ProductAlreadyExistsException : BaseException
    {
        public ProductAlreadyExistsException(string productName)
            : base($"Product with name {productName} already exists.", StatusCodes.Status400BadRequest)
        {
        }
    }
}