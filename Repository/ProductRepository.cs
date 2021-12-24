using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        AppDbContext _context;

        public ProductRepository(AppDbContext context)
            : base(context) 
        {
            _context = context;
        }

        public void AddProduct(ReqDataDto productDto)
        {
            var id = _context.Products.Max(p => p.Id);
            id++;

            _context.Products.Add(new Product
            {
                Id = id,
                Name = productDto.ProductName,
                Description = productDto.ProductDescription,
            }); ;


            _context.ShopProducts.Add(new ShopProduct
            {
                ProductId = id,
                ShopId = productDto.Page
            });
        }


        public void DropProduct(int productId)
        {
            _context.Products.Remove(_context.Products.First(p => p.Id == productId));
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts(int shopId)
        {
            IQueryable<Product> queryable = _context.Products.Where(s => s.ShopProducts.Any(p => p.ShopId == shopId));
  
            return await queryable.ToListAsync();
        }

        public void Update(ReqDataDto productDto)
        {
            var product = _context.Products.Where(p => p.Id == productDto.Id).FirstOrDefault();

            product.Name = productDto.EditProdName;

            product.Description = productDto.EditProdDescription;
        }
    }
}
