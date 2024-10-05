using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // CategoryNotFoundException.cs
    public class CategoryNotFoundException : BaseException
    {
        public CategoryNotFoundException(int categoryId)
            : base($"Category with id {categoryId} was not found.", StatusCodes.Status404NotFound)
        {
        }
    }
}