using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using General.Password;
using General.Response;
using UserManagementService.Requests.User;
using UserManagementService.Services.Interfaces;

namespace UserManagementService.Services.Implementations
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Response<object>> Register(UserRegisterRequest request)
        {
            try
            {
                User? user = await _userRepository.FindSingle(u => u.Auth.Username == request.Username || u.Email == request.Email);

                if (user != null) return new ErrorResponse<object>("EU100", false, "User with specified credentials already exist");

                var (passwordHash, salt) = PasswordHash.GeneratePasswordHash(request.Password);

                user = await _userRepository.Insert(new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    RegisteredOn = DateTime.UtcNow,
                    Auth = new() { PasswordHash = passwordHash, PasswordSalt = salt, Username = request.Username },
                });

                return new Response<object>(true, $"Succcesfully registered user: {user.Auth.Username}. Please login now!");
            }
            catch (Exception e)
            {
                return new ErrorResponse<object>("EE", message: e.Message);
            }
        }

        public async Task<Response<User>> Login(UserLoginRequest request)
        {
            try
            {
                User? user = await _userRepository.FindSingle(u => u.Auth.Username == request.UsernameOrEmail || u.Email == request.UsernameOrEmail);
                if (user == null)
                {
                    return new ErrorResponse<User>("EU101", message: "User does not exist");
                }

                if (PasswordHash.ValidatePasswordHash(request.Password, user.Auth.PasswordHash, user.Auth.PasswordSalt))
                {
                    return new Response<User>(user);
                }
                else
                {
                    return new ErrorResponse<User>("EU102", user, "Invalid username or password");
                }
            }
            catch (Exception e)
            {
                return new ErrorResponse<User>("EE100", message: e.Message);
            }
        }
    }
}