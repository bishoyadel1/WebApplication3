using AutoMapper;
using Domin.Entities.Order;
using Infrastucture.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication3.DTO;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder(Address order)
        {
            if(ModelState.IsValid) 
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var findbyemail = await unitOfWork.userManager.FindByEmailAsync(email);
                var userId = await unitOfWork.userManager.GetUserIdAsync(findbyemail);
                var result =  await unitOfWork.OrderServices.CreateOrder(userId, order);
                if (result is not null ) {
                 return Ok(result);
                }
                else return BadRequest(result);
            }
            return BadRequest ();
        }
        [HttpGet("GetUserOrderDetails")]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetUserOrderDetails()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var findbyemail = await unitOfWork.userManager.FindByEmailAsync(email);
            var userId = await unitOfWork.userManager.GetUserIdAsync(findbyemail);
            var result = await unitOfWork.OrderServices.GetUserOrders(userId);
         
            if (result is not null)
            {
                return Ok(result);
            }
  
             return NotFound();
 
        }


    }
}
