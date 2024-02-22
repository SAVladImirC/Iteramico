using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Services.Interfaces;
using General.Request;
using General.Response;

namespace DomainService.Services.Implementations
{
    internal class EventService(IEventRepository eventRepository) : IEventService
    {
        private readonly IEventRepository _eventRepository = eventRepository;

        public Task<Response<Event>> Create(IGeneralRequest request)
        {
            throw new NotImplementedException();
        }
    }
}