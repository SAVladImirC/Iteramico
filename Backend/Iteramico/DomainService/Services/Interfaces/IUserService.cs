using DomainRepository.Models;
using General.Response;
using UserManagementService.Requests.User;

namespace UserManagementService.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Response<object>> Register(UserRegisterRequest request);
        public Task<Response<User>> Login(UserLoginRequest request);
    }
}