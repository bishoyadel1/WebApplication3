using Domin.Context;
using Domin.Entities;
using Infrastucture.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository
{
    public class BasketRepostiroy : GenericRepository<UserBasket>, IBasketRepostiroy
    {
        private readonly StoreDbContext storeDbContext;
        private readonly UserManager<IdentityUser> userManager;
        public BasketRepostiroy(StoreDbContext _storeDbContext ) : base(_storeDbContext)
        {
            this.storeDbContext = _storeDbContext;
    
        }

        public int DeleteItemFromUserBasket(string UserID, int ProductId)
        {
            var data = storeDbContext.UserBaskets.Where(i => i.UserId == UserID && i.ProductId ==ProductId).FirstOrDefault();
            if (data != null)
            {
                storeDbContext.UserBaskets.Remove(data);
                return storeDbContext.SaveChanges();
            }
            return 0;
        }

        public   int DeleteUserBasket(string UserID)
        {
          var data=   storeDbContext.UserBaskets.Where(i=>i.UserId==UserID).FirstOrDefault();
            if (data!=null)
            {
                storeDbContext.UserBaskets.Remove(data);
                return storeDbContext.SaveChanges();
            }
            return 0;
        }

        public async Task<IReadOnlyList<UserBasket>> GetAllWithItems(string userId)
            => await storeDbContext.UserBaskets.Where(i => i.UserId == userId).Include(o=>o.Product).ToListAsync();

        public async Task<UserBasket> GetBaketByProductID(int productId, string userId)
               => await storeDbContext.UserBaskets.Where(i => i.ProductId == productId && i.UserId == userId).FirstOrDefaultAsync();



    }
}
