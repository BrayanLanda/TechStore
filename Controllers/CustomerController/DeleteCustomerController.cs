using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Interfaces;

namespace TechStore.Controllers.CustomerController
{
    public class DeleteCustomerController : CustomerControllerBase
    {
        public DeleteCustomerController(ICustomerRepository customerRepository, IMapper mapper)
            : base(customerRepository, mapper) { }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Deletes an existing customer",
        Description = "Removes a customer from the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Tags("customers")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerRepository.DeleteAsync(id);
            return Ok("User deleted successfully");
        }
    }
}