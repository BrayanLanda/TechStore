using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechStore.Errors
{
    public class UserAlreadyExistsException : BaseException
    {
        public UserAlreadyExistsException(string email)
        : base($"User with email {email} already exists.", StatusCodes.Status400BadRequest)
        {
        }
    }
}