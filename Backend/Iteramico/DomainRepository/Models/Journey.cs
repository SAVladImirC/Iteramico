namespace DomainRepository.Models
#nullable disable
{
    public class Journey
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual City To { get; set; }
    }
}