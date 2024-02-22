using DomainRepository.Models;
using DomainService.Requests.Event;
using General.Response;

namespace DomainService.Services.Interfaces
{
    public interface IEventService
    {
        public Task<Response<Event>> CreateEvent(CreateEventRequest request);
        public Task<Response<List<Event>>> GetAllEventsForJourney(int journeyId);
    }
}