using System;
using MoneyManager.Core.Interfaces;
using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;

namespace MoneyManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMoneyManagerContext _context;
        private IRepository<Payment> _paymentRepository;
        private IRepository<Category> _categoryRepository;
 
        public UnitOfWork(IMoneyManagerContext context)
        {
            _context = context;
        }

        public IRepository<Payment> PaymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new Repository<Payment>(_context);
                }
                return _paymentRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new Repository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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
    }
}