using DomainRepository.Models;
using DomainService.Requests.Event;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IEventService eventService) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;

        [HttpGet("{journeyId:int}")]
        public async Task<Response<List<Event>>> GetAllEventsForJourney(int journeyId)
        {
            return await _eventService.GetAllEventsForJourney(journeyId);
        }

        [HttpPost("create")]
        public async Task<Response<Event>> CreateEvent(CreateEventRequest request)
        {
            return await _eventService.CreateEvent(request);
        }
    }
}