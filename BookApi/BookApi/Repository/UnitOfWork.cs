using BookApi.Data;
using BookApi.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        IGenericRepository<User> _users;
        IGenericRepository<Book> _books;
        IGenericRepository<Category> _categories;
        private bool disposed = false;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> Users
        {
            get
            {
                if(_users == null)
                {
                    _users = new GenericRepository<User>(_context);
                }
                return _users;
            }
        }

        public IGenericRepository<Book> Books
        {
            get
            {
                if (_books == null)
                {
                    _books = new GenericRepository<Book>(_context);
                }
                return _books;
            }
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new GenericRepository<Category>(_context);
                }
                return _categories;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
