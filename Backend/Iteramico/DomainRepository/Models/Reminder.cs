namespace DomainRepository.Models
{
#nullable disable
    public class Reminder
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Deadline { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public int ForId { get; set; }
        public virtual User For { get; set; }

        public int JourneyId { get; set; }
        public virtual Journey Journey { get; set; }
    }
}