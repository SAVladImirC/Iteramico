namespace DomainService.Requests.Reminder
{
#nullable disable
    public class CreateReminderRequest
    {
        public string Note { get; set; }
        public DateTime Deadline { get; set; }
        public int CreatorId { get; set; }
        public int ForId { get; set; }
        public int JourneyId { get; set; }
    }
}