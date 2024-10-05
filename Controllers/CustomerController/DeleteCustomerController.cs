using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.CustomerController
{
    public class DeleteCustomerController : CustomerControllerBase
    {
        public DeleteCustomerController(ICustomerRepository customerRepository, IMapper mapper) 
            : base(customerRepository, mapper) { }

        /// <summary>
        /// Deletes a specific customer.
        /// </summary>
        /// <param name="id">The id of the customer to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            await _customerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}