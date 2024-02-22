using DomainRepository.Models;
using DomainService.Requests.Memory;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController(IMemoryService memoryService) : ControllerBase
    {
        private readonly IMemoryService _memoryService = memoryService;

        [HttpGet("{journeyId:int}")]
        public async Task<Response<List<Memory>>> GetAllMemoriesForJourney(int journeyId)
        {
            return await _memoryService.GetAllMemoriesForJourney(journeyId);
        }

        [HttpPost("create")]
        public async Task<Response<Memory>> Create(MemoryCreateRequest request)
        {
            return await _memoryService.CreateMemory(request);
        }
    }
}