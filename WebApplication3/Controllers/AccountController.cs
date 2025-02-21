using AutoMapper;
using Infrastucture.Interface;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTO;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountController(IUnitOfWork _unitOfWork , IMapper _mapper)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid) 
            {
            
            var checkUser = await unitOfWork.userManager.FindByEmailAsync(loginDTO.Email);
            if (checkUser == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
            else
            {
                var passCheck = await unitOfWork.signInManager.CheckPasswordSignInAsync(checkUser, loginDTO.Password, false);
                if (passCheck.Succeeded) 
                {
                    var token = new UserDTO()
                    {
                        Email = checkUser.Email,
                        Name = checkUser.UserName,
                        Token = unitOfWork.TokenServices.CreateToken(checkUser)
                     };
                return Ok(token);
                }
                return Unauthorized();
            }
            }
            return Unauthorized();

        }
        [HttpPost("Rigester")]
        public async Task<ActionResult<UserDTO>> Rigester(RegisterDTO registerDTO)
        {
            if(ModelState.IsValid) 
            {
                var usercheck = await unitOfWork.userManager.FindByEmailAsync(registerDTO.Email);
                if(usercheck != null) 
                {
                    return Unauthorized(new { message = "Email Invaild" });
                }
                var user = new IdentityUser()
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.Email.Split('.')[0],
                    PhoneNumber = registerDTO.Phone

                };
                var adduser = await unitOfWork.userManager.CreateAsync(user,registerDTO.Password);
                if(adduser.Succeeded)
                {
                    var token = new UserDTO()
                    {
                        Email = registerDTO.Email,
                        Name = registerDTO.Email.Split('.')[0],
                        Token = unitOfWork.TokenServices.CreateToken(user)
                    };
                   return Ok(token);
                }
                return Unauthorized();

            }
            return Unauthorized();

        }
        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await unitOfWork.signInManager.SignOutAsync(); // Sign out the user
            return Ok(new { message = "Logged out successfully." });
        }



    }
}
