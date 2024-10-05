using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // ProductNotFoundException.cs
    public class ProductNotFoundException : BaseException
    {
        public ProductNotFoundException(int productId)
            : base($"Product with id {productId} was not found.", StatusCodes.Status404NotFound)
        {
        }
    }
}