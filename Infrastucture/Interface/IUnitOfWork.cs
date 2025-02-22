using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Interface
{
     public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; set; }
        public IBasketRepostiroy BasketRepostiroy { get; set; }
        public ICoursesRepository CoursesRepository { get; set; }
        public IOrderServices   OrderServices { get; set; }
        public ITokenServices TokenServices { get; set; }
        SignInManager<IdentityUser> signInManager { get; set; }
        UserManager<IdentityUser> userManager { get; set; }

    }
}
