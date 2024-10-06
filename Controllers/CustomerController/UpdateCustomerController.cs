using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.CustomerDtos;
using TechStore.Errors;
using TechStore.Interfaces;

namespace TechStore.Controllers.CustomerController
{
    public class UpdateCustomerController : CustomerControllerBase
    {
        public UpdateCustomerController(ICustomerRepository customerRepository, IMapper mapper) 
            : base(customerRepository, mapper) { }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="id">The id of the customer to update.</param>
        /// <param name="customerDto">The updated customer details.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Updates an existing customer",
        Description = "Updates customer information in the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Tags("customers")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new IdNotFoundException("Customer", id);

            _mapper.Map(customerDto, customer);
            await _customerRepository.UpdateAsync(customer);
            return Ok("Customer updated successfully");
        }
    }
}