using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.CategoryController
{
    [ApiController]
    [Route("api/v1/categories")]
    [Produces("application/json")]
    public abstract class CategoryControllerBase : ControllerBase
    {
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IMapper _mapper;

        protected CategoryControllerBase(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
    }
}