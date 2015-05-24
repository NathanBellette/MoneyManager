using System;

namespace MoneyManager.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}