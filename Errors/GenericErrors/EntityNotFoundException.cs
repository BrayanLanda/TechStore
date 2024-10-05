using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    // EntityNotFoundException.cs
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException(string entity, int id)
            : base($"{entity} with id {id} was not found.", StatusCodes.Status404NotFound)
        {
        }
    }
}