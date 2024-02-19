namespace DomainRepository.Models
{
#nullable disable
    public class Reminder
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Deadline { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public int ForId { get; set; }
        public User For { get; set; }

        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}