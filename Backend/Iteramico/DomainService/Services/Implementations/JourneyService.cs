using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Services.Interfaces;
using General.Request;
using General.Response;

namespace DomainService.Services.Implementations
{
    public class JourneyService(IJourneyRepository journeyRepository, IJourneyParticipationRepository journeyParticipationRepository, IUserRepository userRepository) : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository = journeyRepository;
        private readonly IJourneyParticipationRepository _journeyParticipationRepository = journeyParticipationRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Response<object>> AddJourneyParticipation(int journeyId, int userId)
        {
            try
            {
                User? user = await _userRepository.FindSingle(u => u.Id == userId);
                if (user == null) return new ErrorResponse<object>("EU100", message: "User does not exist");

                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == journeyId);
                if (journey == null) return new ErrorResponse<object>("EJ100", message: "Journey does not exist");

                journey.Participations.Add(new()
                {
                    User = user,
                    JoinedOn = DateTime.UtcNow,
                });
                
                await _journeyRepository.Update(journey);

                return new Response<object>();
            }
            catch (Exception ex)
            {
                return new ErrorResponse<object>("EE", message: ex.Message);
            }
        }

        public Task<Response<Journey>> Create(IGeneralRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Journey>> GetJourneyById(int id)
        {
            try
            {
                Journey? j = await _journeyRepository.FindSingle(j => j.Id == id);
                if (j == null)
                    return new ErrorResponse<Journey>("EJ100", message: $"Journey does not exist");
                else
                    return new(j, $"Journey {j.Name} successfully retrieved");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<Journey>("EE", message: ex.Message);
            }
        }

        public async Task<Response<List<JourneyParticipation>>> GetJourneysByUserId(int userId)
        {
            List<JourneyParticipation> result = await _journeyParticipationRepository.GetAllJourneyParticipationsForUser(userId);
            await _journeyParticipationRepository.LoadJourney(result);
            return new(result, "Journeys successfully retrieved");
        }
    }
}