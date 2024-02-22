namespace DomainService.Requests.User
{
#nullable disable
    public class UserSearchRequest
    {
        public int UserId { get; set; }
        public string Keyword { get; set; }
    }
}