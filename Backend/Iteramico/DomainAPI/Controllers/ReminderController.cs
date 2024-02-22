using DomainRepository.Models;
using DomainService.Requests.Reminder;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController(IReminderService reminderService) : ControllerBase
    {
        private readonly IReminderService _reminderService = reminderService;

        [HttpGet("{journeyId:int}")]
        public async Task<Response<List<Reminder>>> GetAllRemindersForJourney(int journeyId)
        {
            return await _reminderService.GetAllRemindersForJourney(journeyId);
        }

        [HttpPost("create")]
        public async Task<Response<Reminder>> CreateReminder(CreateReminderRequest request)
        {
            return await _reminderService.CreateReminder(request);
        }
    }
}