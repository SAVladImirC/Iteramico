namespace DomainRepository.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public char Gender { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual Auth Auth { get; set; } = new();

        public virtual List<JourneyParticipation> Participations { get; set; } = [];
        public virtual List<ExpenseParticipation> Expenses { get; set; } = [];
        public virtual List<ExpenseParticipation> Pays { get; set; } = [];

        public virtual List<Reminder> Reminders { get; set; } = [];
    }
}