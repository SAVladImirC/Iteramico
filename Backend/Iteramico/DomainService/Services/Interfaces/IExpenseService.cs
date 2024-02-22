using DomainRepository.Models;
using DomainService.Requests.Expense;
using General.Response;

namespace DomainService.Services.Interfaces
{
    public interface IExpenseService
    {
        public Task<Response<Expense>> CreateExpense(CreateExpenseRequest request);
        public Task<Response<List<Expense>>> GetAllExpensesForJourney(int journeyId);
    }
}