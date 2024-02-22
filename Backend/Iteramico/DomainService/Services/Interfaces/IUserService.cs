using DomainRepository.Models;
using DomainService.Requests.User;
using General.Response;

namespace DomainService.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Response<object>> Register(UserRegisterRequest request);
        public Task<Response<User>> Login(UserLoginRequest request);
    }
}