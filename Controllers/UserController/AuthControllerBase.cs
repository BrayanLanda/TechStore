using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class AuthControllerBase : ControllerBase
    {
        protected readonly IAuthRepository _authRepository;

        public AuthControllerBase(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
    }
}