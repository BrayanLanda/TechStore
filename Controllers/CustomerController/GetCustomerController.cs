using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.CustomerController
{
    public class GetCustomerController : CustomerControllerBase
    {
        public GetCustomerController(ICustomerRepository customerRepository, IMapper mapper) 
            : base(customerRepository, mapper) { }


        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Tags("customers")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Tags("customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }
    }
}