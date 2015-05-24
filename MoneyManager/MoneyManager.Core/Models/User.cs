using System;
using System.Collections;
using System.Collections.Generic;

namespace MoneyManager.Core.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}