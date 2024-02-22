namespace DomainRepository.Models
{
#nullable disable
    public class TravelBuddy
    {
        public int User1Id { get; set; }
        public virtual User User1 { get; set; }
        public int User2Id { get; set; }
        public virtual User User2 { get; set; }
        public DateTime From { get; set; }
    }
}