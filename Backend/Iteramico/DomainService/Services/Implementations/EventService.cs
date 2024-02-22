using Azure.Core;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Requests.Event;
using DomainService.Requests.Event;
using DomainService.Services.Interfaces;
using General.Request;
using General.Response;

namespace DomainService.Services.Implementations
{
    internal class EventService(IEventRepository eventRepository, IUserRepository userRepository, IJourneyRepository journeyRepository) : IEventService
    {
        private readonly IEventRepository _eventRepository = eventRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJourneyRepository _journeyRepository = journeyRepository;

        public async Task<Response<Event>> CreateEvent(CreateEventRequest request)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == request.JourneyId);
                if (journey == null) return new ErrorResponse<Event>("ER100", message: "Journey does not exist");

                User? creator = await _userRepository.FindSingle(u => u.Id == request.CreatorId);
                if (creator == null) return new ErrorResponse<Event>("ER100", message: "User does not exist");

                Event @event = await _eventRepository.Insert(new()
                {
                    Name = request.Name,
                    From = request.From,
                    To = request.To,
                    Creator = creator,
                    Journey = journey,
                });

                return new Response<Event>(@event, "Successfully created a event");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<Event>("EE", message: ex.Message);
            }
        }

        public async Task<Response<List<Event>>> GetAllEventsForJourney(int journeyId)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == journeyId);
                if (journey == null) return new ErrorResponse<List<Event>>("ER100", message: "Journey does not exist");

                List<Event> reminders = await _eventRepository.FindAll(r => r.Journey == journey);
                return new Response<List<Event>>(reminders, message: "Succesfully retrieved events");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<List<Event>>("EE", message: ex.Message);
            }
        }
    }
}