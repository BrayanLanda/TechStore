using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.CategoryDtos;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Controllers.CategoryController
{
    public class CreateCategoryController : CategoryControllerBase
    {
        public CreateCategoryController(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper) { }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new category",
        Description = "Adds a new category to the database.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Tags("categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            return CreatedAtRoute(nameof(GetCategoryController.GetCategory), new { id = category.Id }, category);
        }
    }
}