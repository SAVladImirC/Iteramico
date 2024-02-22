namespace DomainRepository.Models
{
#nullable disable
    public class Memory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public DateTime PostedOn { get; set; }

        public virtual User Creator {  get; set; }
        public virtual Journey Journey { get; set; }
    }
}