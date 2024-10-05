using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.CustomerController
{
    [ApiController]
    [Route("api/v1/customers")]
    [Produces("application/json")]
    [Tags("Customers")]
    public abstract class CustomerControllerBase : ControllerBase
    {
        protected readonly ICustomerRepository _customerRepository;
        protected readonly IMapper _mapper;

        protected CustomerControllerBase(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
    }
}