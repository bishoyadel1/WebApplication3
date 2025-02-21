using Domin.Context;
using Domin.Entities;
using Infrastucture.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Helper;

namespace Infrastucture.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly StoreDbContext  Context;

        public ProductRepository(StoreDbContext _storeDbContext) : base(_storeDbContext)
        {
             Context = _storeDbContext;
        }

        public async Task<Product> GetProductDetails(int Id)
        {
            return await Context.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsBySpcification(ProductPram productPram)
        {
            var data = Context.Products
                .Include(i => i.Category)
                .Include(u => u.Brand)
                .Where(x =>
                    (string.IsNullOrEmpty(productPram.Name) || x.ProductName.Contains(productPram.Name)) &&
                    (productPram.CategoryId == 0 || x.CategoryId == productPram.CategoryId) &&
                    (productPram.BrandId == 0 || x.BrandId == productPram.BrandId)
                );

 
            data = data.OrderBy(x => x.ProductName);

 
            switch (productPram.Sort)
            {
                case "priceDSC":
                    data = data.OrderByDescending(x => x.Price);
                    break;
                case "priceASC":
                    data = data.OrderBy(x => x.Price);
                    break;
            }

      
            int pageSize = 10;
            int skipAmount = productPram.PageNum == 0 ? 1 : (productPram.PageNum - 1) * pageSize;
            data = data.Skip(skipAmount).Take(pageSize);

            return await data.ToListAsync();
        }
    }
}
