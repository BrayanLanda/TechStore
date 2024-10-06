using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.DTOs.CategoryDtos;
using TechStore.Errors;
using TechStore.Interfaces;

namespace TechStore.Controllers.CategoryController
{
    public class UpdateCategoryController : CategoryControllerBase
    {
        public UpdateCategoryController(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper) { }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Updates an existing category",
        Description = "Updates category information in the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Tags("categories")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new IdNotFoundException("Category", id);

            _mapper.Map(categoryDto, category);
            await _categoryRepository.UpdateAsync(category);
            return Ok("Category updated successfully");
        }
    }
}