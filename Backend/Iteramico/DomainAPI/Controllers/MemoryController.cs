using DomainService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController(IMemoryService memoryService) : ControllerBase
    {
        private readonly IMemoryService _memoryService = memoryService;
    }
}