using AutoMapper;
using Domin.Entities;
using Infrastucture.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTO;
using WebApplication3.Helper;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
           unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts([FromQuery]ProductPram pram) 
        {
            
            var products = await unitOfWork.ProductRepository.GetProductsBySpcification(pram);
            var productsListDTO= mapper.Map<IReadOnlyList<ProductDTO>>(products);
            return Ok(productsListDTO);
        }
    }
}
