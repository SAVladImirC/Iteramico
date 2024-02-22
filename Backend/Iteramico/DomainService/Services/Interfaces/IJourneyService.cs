using DomainRepository.Models;
using General.Response;
using General.Service;

namespace DomainService.Services.Interfaces
{
    public interface IJourneyService : IGeneralService<Journey>
    {
        public Task<Response<List<JourneyParticipation>>> GetJourneysByUserId(int userId);
        public Task<Response<Journey>> GetJourneyById(int id);
    }
}