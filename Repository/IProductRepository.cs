using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProducts(int shopId);
        void AddProduct(ReqDataDto productDto);
        Task<Product> GetProductById(int id);
        void Update(ReqDataDto product);
        void DropProduct(int productId);
    }
}
