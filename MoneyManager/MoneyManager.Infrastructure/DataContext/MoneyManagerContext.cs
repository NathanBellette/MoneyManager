using System;
using System.Data.Entity;
using System.Net.NetworkInformation;
using MoneyManager.Core.Interfaces;
using MoneyManager.Core.Models;

namespace MoneyManager.Infrastructure.DataContext
{
    public class MoneyManagerContext : DbContext, IMoneyManagerContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories  { get; set; }

        public MoneyManagerContext() : base("MoneyManager")
        {
            
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateAdded = DateTime.Now;
                        entry.Entity.DateModified = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}