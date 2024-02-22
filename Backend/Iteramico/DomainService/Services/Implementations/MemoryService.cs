using Azure.Core;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Requests.Memory;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.Extensions.Configuration;

namespace DomainService.Services.Implementations
{
    internal class MemoryService(IMemoryRepository memoryRepository, IJourneyRepository journeyRepository, IUserRepository userRepository, IConfiguration configuration) : IMemoryService
    {
        private readonly IMemoryRepository _memoryRepository = memoryRepository;
        private readonly IJourneyRepository _journeyRepository = journeyRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IConfiguration _configuration = configuration;

        public async Task<Response<Memory>> CreateMemory(MemoryCreateRequest request)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == request.JourneyId);
                if (journey == null) return new ErrorResponse<Memory>("EJ100", message: "Journey does not exist");

                User? user = await _userRepository.FindSingle(u => u.Id == request.CreatorId);
                if (user == null) return new ErrorResponse<Memory>("EU100", message: "User does not exist");

                Memory memory = await _memoryRepository.Insert(new()
                {
                    ImageBase64 = request.Base64image,
                    Name = request.Name,
                    PostedOn = DateTime.UtcNow,
                    Creator = user,
                    Journey = journey
                });

                return new Response<Memory>(memory, "Sucessfully created a memory");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<Memory>("EE", message: ex.Message);
            }
        }

        public async Task<Response<List<Memory>>> GetAllMemoriesForJourney(int journeyId)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == journeyId);
                if (journey == null) return new ErrorResponse<List<Memory>>("EJ100", message: "Journey does not exist");
                List<Memory> memories = await _memoryRepository.FindAll(m => m.Journey == journey);
                return new Response<List<Memory>>(memories, message: $"Sucessfully retrieved memories for joruney {journey.Name}");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<List<Memory>>("EE", message: ex.Message);
            }
        }
    }
}