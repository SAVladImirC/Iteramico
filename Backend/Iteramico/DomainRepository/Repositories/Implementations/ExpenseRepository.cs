using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;

namespace DomainRepository.Repositories.Implementations
{
    internal class ExpenseRepository(DomainContext context) : GeneralRepository<Expense, DomainContext>(context), IExpenseRepository
    {
    }
}