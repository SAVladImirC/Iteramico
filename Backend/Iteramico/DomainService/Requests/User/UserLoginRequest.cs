namespace DomainService.Requests.User
{
#nullable disable
    public class UserLoginRequest
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}