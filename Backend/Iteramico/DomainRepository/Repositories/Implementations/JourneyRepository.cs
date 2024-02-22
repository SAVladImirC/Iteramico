using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;

namespace DomainRepository.Repositories.Implementations
{
    internal class JourneyRepository(DomainContext context) : GeneralRepository<Journey, DomainContext>(context), IJourneyRepository
    {
    }
}