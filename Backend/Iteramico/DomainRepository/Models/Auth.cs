using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DomainRepository.Models
{
#nullable disable
    public class Auth
    {
        [JsonIgnore]
        public int UserId { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(500)]
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public int LoginAttempts { get; set; }
    }
}