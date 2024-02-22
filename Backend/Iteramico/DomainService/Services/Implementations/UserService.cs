using Azure.Core;
using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Requests.User;
using DomainService.Services.Interfaces;
using General.Password;
using General.Response;

namespace DomainService.Services.Implementations
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

        public async Task<Response<List<User>>> GetAllJourneyParticipants(int journeyId)
        {
            try
            {
                List<User> participants = await _userRepository.FindAll(u => u.Participations.Any(p => p.JourneyId == journeyId));
                return new Response<List<User>>(participants, "Journey participants retrieved succesffully");
            }
            catch (Exception e)
            {
                return new ErrorResponse<List<User>>("EE100", message: e.Message);
            }
        }

        public async Task<Response<object>> BecomeTravelBuddy(int currentUserId, int withId)
        {
            try
            {
                User? current = await _userRepository.FindSingle(u => u.Id == currentUserId);
                if (current == null) return new ErrorResponse<object>("ER100", message: "Sender user does not exist");

                User? with = await _userRepository.FindSingle(u => u.Id == withId);
                if (with == null) return new ErrorResponse<object>("ER100", message: "Parameter user does not exist");

                current.TravelBuddies.Add(new() { User2 = with, From = DateTime.UtcNow });

                await _userRepository.Update(current);

                return new Response<object>();
            }
            catch (Exception e)
            {
                return new ErrorResponse<object>("EE100", message: e.Message);
            }
        }

        public async Task<Response<List<User>>> GetAllTravelBuddies(int userId)
        {
            try
            {
                User? user = await _userRepository.FindSingle(u => u.Id == userId);
                if (user == null) return new ErrorResponse<List<User>>("ER100", message: "User does not exist");

                await _userRepository.LoadTravelBuddies(user);

                List<int> travelBuddyIds = user.TravelBuddies.Select(tb => tb.User2Id).ToList();

                List<User> travelBuddies = await _userRepository.FindAll(u => travelBuddyIds.Contains(u.Id));

                return new Response<List<User>>(travelBuddies, "Travel buddies sucessfully retrieved");
            }
            catch (Exception e)
            {
                return new ErrorResponse<List<User>>("EE100", message: e.Message);
            }
        }

        public async Task<Response<List<User>>> SearchUsers(int userId, string keyword)
        {
            try
            {
                List<User> matchedUsers;
                List<User>? travelBuddies = (await GetAllTravelBuddies(userId)).Data;
                if (travelBuddies != null && travelBuddies.Count > 0)
                {
                    List<int> travelBuddyIds = travelBuddies.Select(tb => tb.Id).ToList();
                    matchedUsers = await _userRepository.FindAll(u => u.Auth.Username.Contains(keyword) && u.Id != userId && !travelBuddyIds.Contains(u.Id));
                }
                else
                {
                    matchedUsers = await _userRepository.FindAll(u => u.Auth.Username.Contains(keyword) && u.Id != userId);
                }
                return new Response<List<User>>(matchedUsers);
            }
            catch (Exception e)
            {
                return new ErrorResponse<List<User>>("EE100", message: e.Message);
            }
        }
    }
}