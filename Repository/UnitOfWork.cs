using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IShopRepository Shops { get; }
        public IProductRepository Products { get; }
        public UnitOfWork(AppDbContext context,
            IShopRepository shopRepository,
            IProductRepository productRepository
           )
        {
            _context = context;
            Shops = shopRepository;
            Products = productRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
