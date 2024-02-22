using DomainRepository.Models;
using General.Repository;

namespace DomainRepository.Repositories.Interfaces
{
    public interface IEventRepository : IGeneralRepository<Event>
    {
    }
}