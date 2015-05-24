using MoneyManager.Core.Models;

namespace MoneyManager.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Payment> PaymentRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        void Commit();
    }
}