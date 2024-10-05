using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // CategoryAlreadyExistsException.cs
    public class CategoryAlreadyExistsException : BaseException
    {
        public CategoryAlreadyExistsException(string categoryName)
            : base($"Category with name {categoryName} already exists.", StatusCodes.Status400BadRequest)
        {
        }
    }
}