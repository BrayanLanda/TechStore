using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechStore.Interfaces;

namespace TechStore.Controllers.ProductController
{
    [ApiController]
    [Route("api/v1/products")]
    [Produces("application/json")]
    public abstract class ProductControllerBase : ControllerBase
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IMapper _mapper;

        protected ProductControllerBase(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
    }
}