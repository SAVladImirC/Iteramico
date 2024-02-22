using DomainRepository.Models;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController(IJourneyService journeyService) : ControllerBase
    {
        private readonly IJourneyService _journeyService = journeyService;

        [HttpGet("by-id/{id:int}")]
        public async Task<Response<Journey>> GetJourneyById(int id)
        {
            return await _journeyService.GetJourneyById(id);
        }

        [HttpGet("by-user/{userId:int}")]
        public async Task<Response<List<JourneyParticipation>>> GetJourneysByUserId(int userId)
        {
            return await _journeyService.GetJourneysByUserId(userId);
        }
    }
}