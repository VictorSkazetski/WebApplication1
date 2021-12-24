using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IShopRepository Shops { get; }
        IProductRepository Products { get; }
        int Complete();
    }
}
