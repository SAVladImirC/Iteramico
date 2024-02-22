namespace DomainService.Requests.Expense
{
#nullable disable
    public class CreateExpenseRequest
    {
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public int CreatorId {  get; set; }
        public int JourneyId { get; set; }
        public List<int> Participants { get; set; }
    }
}