using BookApi.Data;
using BookApi.IRepository;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<Tuple<List<T>, Pagination>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null, Pagination pagination = null)
        {
            IQueryable<T> query = _db;
            
            if(expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            Pagination pagingInfo = new Pagination();
            int count = query.AsNoTracking().Count();
            if(pagination != null)
            {
                query = query.Take(pagination.ItemsPerPage).Skip((pagination.CurrentPage - 1) * pagination.ItemsPerPage);

                pagingInfo.CurrentPage = pagination.CurrentPage > 0 ? pagination.CurrentPage : 1;
                pagingInfo.TotalItem = count;
            }

            var list = await query.AsNoTracking().ToListAsync();

            return new Tuple<List<T>, Pagination>(list, pagingInfo);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
