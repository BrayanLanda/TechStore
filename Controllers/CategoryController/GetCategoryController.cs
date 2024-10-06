using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.CategoryController
{
    public class GetCategoryController : CategoryControllerBase
    {
        public GetCategoryController(ICategoryRepository categoryRepository, IMapper mapper)
            : base(categoryRepository, mapper) { }

        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Tags("categories")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Tags("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }
    }
}