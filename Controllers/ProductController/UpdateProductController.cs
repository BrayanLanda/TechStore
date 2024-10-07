using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.ProductDtos;
using TechStore.Errors;
using TechStore.Interfaces;

namespace TechStore.Controllers.ProductController
{
    public class UpdateProductController : ProductControllerBase
{
    public UpdateProductController(IProductRepository productRepository, IMapper mapper)
        : base(productRepository, mapper) { }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    [SwaggerOperation(
    Summary = "Updates an existing product",
    Description = "Updates product information in the database.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Tags("products")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new IdNotFoundException("Product", id);

        _mapper.Map(productDto, product);
        await _productRepository.UpdateAsync(product);
        return Ok("Product updated successfully");
    }
}
}