using Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Interface
{
    public interface IBasketRepostiroy : IGenericRepository<UserBasket>
    {
        public Task<IReadOnlyList<UserBasket>> GetAllWithItems (string userId);
        public Task<UserBasket>  GetBaketByProductID(int productId,string userId);
        public int DeleteUserBasket(string UserID);
        public int DeleteItemFromUserBasket(string UserID,int ProductId);
    }
}
