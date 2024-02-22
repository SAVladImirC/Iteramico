using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Requests.Reminder;
using DomainService.Services.Interfaces;
using General.Response;

namespace DomainService.Services.Implementations
{
    internal class ReminderService(IReminderRepository reminderRepository, IUserRepository userRepository, IJourneyRepository journeyRepository) : IReminderService
    {
        private readonly IReminderRepository _reminderRepository = reminderRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJourneyRepository _journeyRepository = journeyRepository;

        public async Task<Response<Reminder>> CreateReminder(CreateReminderRequest request)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == request.JourneyId);
                if (journey == null) return new ErrorResponse<Reminder>("ER100", message: "Journey does not exist");

                User? creator = await _userRepository.FindSingle(u => u.Id == request.CreatorId);
                if (creator == null) return new ErrorResponse<Reminder>("ER100", message: "User does not exist");

                User? dedicatedTo = await _userRepository.FindSingle(u => u.Id == request.ForId);
                if (creator == null) return new ErrorResponse<Reminder>("ER100", message: "User does not exist");

                Reminder reminder = await _reminderRepository.Insert(new()
                {
                    Journey = journey,
                    Creator = creator,
                    For = dedicatedTo,
                    Deadline = request.Deadline,
                    Note = request.Note,
                });

                return new Response<Reminder>(reminder, "Successfully created a reminder");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<Reminder>("EE", message: ex.Message);
            }
        }

        public async Task<Response<List<Reminder>>> GetAllRemindersForJourney(int journeyId)
        {
            try
            {
                List<Reminder> reminders = await _reminderRepository.FindAll(r => r.JourneyId == journeyId);
                return new Response<List<Reminder>>(reminders, message: "Succesfully retrieved reminders");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<List<Reminder>>("EE", message: ex.Message);
            }
        }
    }
}