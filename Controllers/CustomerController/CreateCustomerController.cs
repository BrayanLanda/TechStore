using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.CustomerDtos;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Controllers.CustomerController
{
    public class CreateCustomerController : CustomerControllerBase
    {
        public CreateCustomerController(ICustomerRepository customerRepository, IMapper mapper)
            : base(customerRepository, mapper) { }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new customer",
        Description = "Adds a new customer to the database.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddAsync(customer);
            return CreatedAtRoute(nameof(GetCustomerController.GetCustomer), new { id = customer.Id }, customer);
        }
    }
}