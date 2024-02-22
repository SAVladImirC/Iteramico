using DomainRepository.Models;
using DomainService.Requests.User;
using General.Response;

namespace DomainService.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Response<object>> Register(UserRegisterRequest request);
        public Task<Response<User>> Login(UserLoginRequest request);
        public Task<Response<object>> BecomeTravelBuddy(int currentUserId, int withId);
        public Task<Response<List<User>>> GetAllJourneyParticipants(int journeyId);
        public Task<Response<List<User>>> GetAllTravelBuddies(int userId);
        public Task<Response<List<User>>> SearchUsers(int userId, string keyword);
    }
}