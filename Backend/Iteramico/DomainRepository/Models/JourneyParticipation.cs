using System.Text.Json.Serialization;

namespace DomainRepository.Models
{
#nullable disable
    public class JourneyParticipation
    {
        public DateTime JoinedOn { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public int JourneyId { get; set; }
        public virtual Journey Journey { get; set; }
    }
}