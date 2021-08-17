using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookApi.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<Tuple<List<T>, Pagination>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null,
            Pagination pagination = null);

        Task<T> Get(
            Expression<Func<T, bool>> expression = null,
            List<string> includes = null);

        void Update(T entity);
    }
}
