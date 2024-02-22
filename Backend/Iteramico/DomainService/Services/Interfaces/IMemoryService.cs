using DomainRepository.Models;
using DomainService.Requests.Memory;
using General.Response;

namespace DomainService.Services.Interfaces
{
    public interface IMemoryService
    {
        public Task<Response<Memory>> CreateMemory(MemoryCreateRequest request);
        public Task<Response<List<Memory>>> GetAllMemoriesForJourney(int journeyId);
    }
}