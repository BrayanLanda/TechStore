using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    public class UnauthorizedAccessException : BaseException
    {
        public UnauthorizedAccessException(string action)
            : base($"You do not have permission to perform this action: {action}.", StatusCodes.Status403Forbidden)
        {
        }
    }
}