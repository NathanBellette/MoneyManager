using MoneyManager.Core.Enums;

namespace MoneyManager.Core.Models
{
    public class Payment : BaseEntity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public Category Category { get; set; }
    }
}