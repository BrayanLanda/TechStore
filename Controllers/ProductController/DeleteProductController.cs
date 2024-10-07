using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Interfaces;

namespace TechStore.Controllers.ProductController
{
    public class DeleteProductController : ProductControllerBase
{
    public DeleteProductController(IProductRepository productRepository, IMapper mapper)
        : base(productRepository, mapper) { }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    [SwaggerOperation(
    Summary = "Deletes an existing product",
    Description = "Removes a product from the database.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Tags("products")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productRepository.DeleteAsync(id);
        return Ok("Product deleted successfully");
    }
}
}