namespace DomainRepository.Models
{
#nullable disable
    public class JourneyParticipation
    {
        public DateTime JoinedOn { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}