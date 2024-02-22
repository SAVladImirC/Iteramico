using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;

namespace DomainRepository.Repositories.Implementations
{
    internal class EventRepository(DomainContext context) : GeneralRepository<Event, DomainContext>(context), IEventRepository
    {
    }
}