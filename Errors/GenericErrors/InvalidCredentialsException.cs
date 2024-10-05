using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    public class InvalidCredentialsException : BaseException
    {
        public InvalidCredentialsException()
        : base("Invalid username or password.", StatusCodes.Status401Unauthorized)
        {
        }
    }
}