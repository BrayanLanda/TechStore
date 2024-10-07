using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.ProductDtos;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Controllers.ProductController
{
    public class CreateProductController : ProductControllerBase
    {
        public CreateProductController(IProductRepository productRepository, IMapper mapper)
            : base(productRepository, mapper) { }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new product",
        Description = "Adds a new product to the database.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("products")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                // Devolverá los errores de validación si los datos no son válidos
                return BadRequest(ModelState);
            }
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            return CreatedAtRoute(nameof(GetProductController.GetProduct), new { id = product.Id }, product);
        }
    }
}