using DomainRepository.Models;
using DomainService.Requests.Reminder;
using General.Response;

namespace DomainService.Services.Interfaces
{
    public interface IReminderService
    {
        public Task<Response<Reminder>> CreateReminder(CreateReminderRequest request);
        public Task<Response<List<Reminder>>> GetAllRemindersForJourney(int journeyId);
    }
}