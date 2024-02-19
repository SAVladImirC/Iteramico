namespace DomainRepository.Models
{
#nullable disable
    public class Memory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedOn { get; set; }

        public User Creator {  get; set; }
        public Journey Journey { get; set; }
    }
}