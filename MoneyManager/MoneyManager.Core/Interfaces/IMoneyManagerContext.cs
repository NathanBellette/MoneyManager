using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MoneyManager.Core.Models;

namespace MoneyManager.Core.Interfaces
{
    public interface IMoneyManagerContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Category> Categories { get; set; } 
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry(object entry);
        int SaveChanges();
        void Dispose();
    }
}