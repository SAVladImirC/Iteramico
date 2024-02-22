namespace DomainService.Requests.Event
{
#nullable disable
    public class CreateEventRequest
    {
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public int JourneyId { get; set;}
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}