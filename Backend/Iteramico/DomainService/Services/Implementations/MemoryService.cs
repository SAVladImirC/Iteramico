using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Services.Interfaces;
using General.Request;
using General.Response;

namespace DomainService.Services.Implementations
{
    internal class MemoryService(IMemoryRepository memoryRepository) : IMemoryService
    {
        private readonly IMemoryRepository _memoryRepository = memoryRepository;

        public Task<Response<Memory>> Create(IGeneralRequest request)
        {
            throw new NotImplementedException();
        }
    }
}