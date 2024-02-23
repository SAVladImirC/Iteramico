namespace DomainRepository.Models
{
    public class ExpenseParticipation
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = new();

        public int ExpenseId { get; set; }
        public virtual Expense Expense { get; set; } = new();

        public int? PayerId { get; set; }
        public virtual User? Payer { get; set; }

        public decimal SubTotal { get; set; }
    }
}