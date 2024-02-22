using DomainRepository.Models;
using DomainService.Requests.User;
using DomainService.Services.Interfaces;
using General.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


        [HttpPost("register")]
        public async Task<Response<object>> Register(UserRegisterRequest request)
        {
            return await _userService.Register(request);
        }

        [HttpPost("login")]
        public async Task<Response<User>> Login(UserLoginRequest request)
        {
            return await _userService.Login(request);
        }

        [HttpGet("by-journey/{journeyId:int}")]
        public async Task<Response<List<User>>> GetAllJourneyParticipants(int journeyId)
        {
            return await _userService.GetAllJourneyParticipants(journeyId);
        }

        [HttpGet("add-travel-buddy/{currentUserId:int}/{withId:int}")]
        public async Task<Response<object>> BecomeTravelBuddy(int currentUserId, int withId)
        {
            return await _userService.BecomeTravelBuddy(currentUserId, withId);
        }

        [HttpGet("travel-buddies/{id:int}")]
        public async Task<Response<List<User>>> GetAllTravelBuddies(int id)
        {
            return await _userService.GetAllTravelBuddies(id);
        }

        [HttpPost("search")]
        public async Task<Response<List<User>>> SearchUsers(UserSearchRequest request)
        {
            return await _userService.SearchUsers(request.UserId, request.Keyword);
        }
    }
}