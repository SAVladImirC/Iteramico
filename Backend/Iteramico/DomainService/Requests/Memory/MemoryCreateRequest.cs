using General.Request;

namespace DomainService.Requests.Memory
{
#nullable disable
    public class MemoryCreateRequest : IGeneralRequest
    {
        public string Base64image { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public int JourneyId { get; set; }
    }
}