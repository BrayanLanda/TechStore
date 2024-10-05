using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    public class ProductOutOfStockException : BaseException
    {
        public ProductOutOfStockException(int productId)
            : base($"Product with id {productId} is out of stock.", StatusCodes.Status400BadRequest)
        {
        }
    }
}