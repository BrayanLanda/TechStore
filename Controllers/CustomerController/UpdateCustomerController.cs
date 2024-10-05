using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.DTOs.CustomerDtos;
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
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            _mapper.Map(customerDto, customer);
            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }
    }
}