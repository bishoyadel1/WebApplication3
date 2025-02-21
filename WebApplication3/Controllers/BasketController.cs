using AutoMapper;
using Domin.Entities;
using Infrastucture.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication3.DTO;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BasketController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        [Authorize]
        [HttpGet]
   
        public async Task<ActionResult<IReadOnlyList<BasketDTO>>> GetBasket( )
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var findbyemail = await unitOfWork.userManager.FindByEmailAsync(email);
            var userId = await unitOfWork.userManager.GetUserIdAsync(findbyemail);
            if (userId == null) { return NotFound(); }
            var model = await unitOfWork.BasketRepostiroy.GetAllWithItems(userId.ToString());
            if(model == null) { return Ok(); }
            var modelDTO = mapper.Map<BasketDTO>(model);

            return Ok(modelDTO);


        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<BasketDTO>>> AddBasket(int productID ,int Count)
        {
           if(ModelState.IsValid)
            {
                var user = await unitOfWork.userManager.GetUserAsync(User);
                var userId = user.Id;

                if (userId == null) { return NotFound(); }   

                var product = await unitOfWork.BasketRepostiroy.GetBaketByProductID(productID, userId);
                if (product != null)
                {
                    unitOfWork.BasketRepostiroy.Update(product);
                    return Ok(product);
                }
                else
                {
                    var data = new UserBasket()
                    {
                        UserId = userId,
                        ProductCount = Count,
                        ProductId = productID
                    };

                    unitOfWork.BasketRepostiroy.Add(data);
                    return Ok(data);
                }

            }
            return BadRequest();


        }
    }
}
