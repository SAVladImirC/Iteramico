using DomainRepository.Models;
using DomainService.Requests.Expense;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController(IExpenseService expenseService) : ControllerBase
    {
        private readonly IExpenseService _expenseService = expenseService;

        [HttpGet("{journeyId:int}")]
        public async Task<Response<List<Expense>>> GetAllExpensesForJourney(int journeyId)
        {
            return await _expenseService.GetAllExpensesForJourney(journeyId);
        }

        [HttpPost("create")]
        public async Task<Response<Expense>> CreateExpense(CreateExpenseRequest request)
        {
            return await _expenseService.CreateExpense(request);
        }
    }
}