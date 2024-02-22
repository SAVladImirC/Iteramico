using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;

namespace DomainRepository.Repositories.Implementations
{
    internal class MemoryRepository(DomainContext context) : GeneralRepository<Memory, DomainContext>(context), IMemoryRepository
    {
    }
}