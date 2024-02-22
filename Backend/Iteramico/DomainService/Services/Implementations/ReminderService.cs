using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Services.Interfaces;
using General.Request;
using General.Response;

namespace DomainService.Services.Implementations
{
    internal class ReminderService(IReminderRepository reminderRepository) : IReminderService
    {
        private readonly IReminderRepository _reminderRepository = reminderRepository;

        public Task<Response<Reminder>> Create(IGeneralRequest request)
        {
            throw new NotImplementedException();
        }
    }
}