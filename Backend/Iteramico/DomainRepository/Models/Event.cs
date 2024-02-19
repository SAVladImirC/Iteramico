namespace DomainRepository.Models
{
#nullable disable
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public virtual User Creator { get; set; }
        public virtual Journey Journey { get; set; }
    }
}