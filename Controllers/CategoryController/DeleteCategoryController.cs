using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechStore.Interfaces;

namespace TechStore.Controllers.CategoryController
{
    public class DeleteCategoryController : CategoryControllerBase
    {
        public DeleteCategoryController(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper) { }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        [SwaggerOperation(
        Summary = "Deletes an existing category",
        Description = "Removes a category from the database.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Tags("categories")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return Ok("Category deleted successfully");
        }
    }
}