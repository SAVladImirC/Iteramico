namespace DomainRepository.Models
{
#nullable disable
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalName { get; set; }
        public string CountryCode { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}