using DomainRepository.Models;
using General.Repository;

namespace DomainRepository.Repositories.Interfaces
{
    public interface IUserRepository : IGeneralRepository<User>
    {
    }
}