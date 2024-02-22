using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;

namespace DomainRepository.Repositories.Implementations
{
    internal class ReminderRepository(DomainContext context) : GeneralRepository<Reminder, DomainContext>(context), IReminderRepository
    {
    }
}