using Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Helper;

namespace Infrastucture.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<IReadOnlyList<Product>> GetProductsBySpcification(ProductPram productPram );
        public Task<Product> GetProductDetails(int Id);

    }
}
