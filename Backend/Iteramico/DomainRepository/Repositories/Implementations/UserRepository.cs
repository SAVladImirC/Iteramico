using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;

namespace DomainRepository.Repositories.Implementations
{
    internal class UserRepository(DomainContext context) : GeneralRepository<User, DomainContext>(context), IUserRepository
    {
    }
}