using DomainRepository.Context;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Repository;
using Microsoft.EntityFrameworkCore;

namespace DomainRepository.Repositories.Implementations
{
    internal class JourneyParticipationRepository(DomainContext context) : GeneralRepository<JourneyParticipation, DomainContext>(context), IJourneyParticipationRepository
    {
        public async Task<List<JourneyParticipation>> GetAllJourneyParticipationsForUser(int userId)
        {
            return await _context.JourneyParticipations.Where(jp => jp.UserId == userId).ToListAsync();
        }

        public async Task LoadJourney(JourneyParticipation journeyParticipation)
        {
            await _context.Entry(journeyParticipation).Reference(jp => jp.Journey).LoadAsync();
        }

        public async Task LoadJourney(List<JourneyParticipation> journeyParticipations)
        {
            foreach(JourneyParticipation jp in journeyParticipations)
            {
                await LoadJourney(jp);
            }
        }
    }
}