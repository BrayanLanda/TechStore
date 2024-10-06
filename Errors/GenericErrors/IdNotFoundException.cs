using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // CategoryNotFoundException.cs
    public class IdNotFoundException : BaseException
    {
        public IdNotFoundException(string table, int id)
            : base($"{table} with id {id} was not found.", StatusCodes.Status404NotFound)
        {
        }
    }
}