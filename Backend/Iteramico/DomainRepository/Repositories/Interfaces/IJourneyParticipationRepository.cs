using DomainRepository.Models;
using General.Repository;

namespace DomainRepository.Repositories.Interfaces
{
    public interface IJourneyParticipationRepository : IGeneralRepository<JourneyParticipation>
    {
        public Task<List<JourneyParticipation>> GetAllJourneyParticipationsForUser(int userId);

        public Task LoadJourney(JourneyParticipation journeyParticipation);
        public Task LoadJourney(List<JourneyParticipation> journeyParticipations);
    }
}