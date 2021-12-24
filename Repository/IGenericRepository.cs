using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> AllItem(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes);
    }
}
