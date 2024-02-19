namespace DomainRepository.Models
{
#nullable disable
    public class Expense
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }

        public virtual User Creator { get; set; }
        public virtual Journey Journey { get; set; }

        public virtual List<ExpenseParticipation> Participations { get; set; } = [];
    }
}