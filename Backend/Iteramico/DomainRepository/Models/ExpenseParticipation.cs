namespace DomainRepository.Models
{
    public class ExpenseParticipation
    {
        public int UserId { get; set; }
        public User User { get; set; } = new();

        public int ExpenseId { get; set; }
        public Expense Expense { get; set; } = new();

        public int? PayerId { get; set; }
        public User? Payer { get; set; }
    }
}