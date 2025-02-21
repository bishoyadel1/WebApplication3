using Infrastucture.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
     
        public UnitOfWork(IProductRepository _ProductRepository , IBasketRepostiroy _BasketRepostiroy, SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> _userManager , ITokenServices _tokenServices , IOrderServices _orderServices)
        {
            ProductRepository = _ProductRepository;
            signInManager= _signInManager;
            userManager= _userManager;
            BasketRepostiroy = _BasketRepostiroy;
            TokenServices= _tokenServices;
            OrderServices = _orderServices;


        }
        public IProductRepository ProductRepository { get ; set  ; }
        public IBasketRepostiroy BasketRepostiroy { get; set; }
        public SignInManager<IdentityUser> signInManager { get; set; }
        public UserManager<IdentityUser> userManager { get; set ; }
        public ITokenServices TokenServices { get ; set  ; }
        public IOrderServices  OrderServices { get  ; set ; }
    }
}
