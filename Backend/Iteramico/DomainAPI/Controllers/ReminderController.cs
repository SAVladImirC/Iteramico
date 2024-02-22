using DomainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController(IReminderService reminderService) : ControllerBase
    {
        private readonly IReminderService _reminderService = reminderService;
    }
}