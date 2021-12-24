using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext _contextDb;

        public GenericRepository(AppDbContext context)
        {
            _contextDb = context;
        }

        public async Task<IList<T>> AllItem(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null) 
        {
            IQueryable<T> queryable = _contextDb.Set<T>();

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable.ToListAsync();
        }
    }
}
