using BookApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.IRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Book> Books { get; }
        IGenericRepository<Category> Categories { get; }
        Task Save();
    }
}
