using DomainRepository.Models;
using DomainRepository.Repositories.Interfaces;
using DomainService.Requests.Expense;
using DomainService.Services.Interfaces;
using General.Response;

namespace DomainService.Services.Implementations
{
    public class ExpenseService(IExpenseRepository expenseRepository, IJourneyRepository journeyRepository, IUserRepository userRepository) : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository = expenseRepository;
        private readonly IJourneyRepository _journeyRepository = journeyRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Response<Expense>> CreateExpense(CreateExpenseRequest request)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == request.JourneyId);
                if (journey == null) return new ErrorResponse<Expense>("ER100", message: "Journey does not exist");

                User? creator = await _userRepository.FindSingle(u => u.Id == request.CreatorId);
                if (creator == null) return new ErrorResponse<Expense>("ER100", message: "User does not exist");

                List<ExpenseParticipation> expenseParticipations = [];

                Expense expense = await _expenseRepository.Insert(new()
                {
                    Creator = creator,
                    Journey = journey,
                    Price = request.Price,
                    Currency = request.Currency,
                    Description = request.Description,
                });

                foreach(int participantId in request.Participants)
                {
                    User? participant = await _userRepository.FindSingle(u => u.Id == participantId);
                    if (participant == null) return new ErrorResponse<Expense>("ER100", message: "User does not exist");

                    expenseParticipations.Add(new() { Expense = expense, Payer = creator, User = participant, SubTotal = expense.Price / request.Participants.Count });
                }

                expense.Participations = expenseParticipations;

                expense = await _expenseRepository.Update(expense);

                return new Response<Expense>(expense, "Expense sucessfully created");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<Expense>("EE", message: ex.Message);
            }
        }

        public async Task<Response<List<Expense>>> GetAllExpensesForJourney(int journeyId)
        {
            try
            {
                Journey? journey = await _journeyRepository.FindSingle(j => j.Id == journeyId);
                if (journey == null) return new ErrorResponse<List<Expense>>("EJ100", message: "Journey does not exist");


                List<Expense> expenses = await _expenseRepository.FindAll(e => e.Journey == journey);
                return new Response<List<Expense>>(expenses, message: "Succesfully retrieved expenses");
            }
            catch (Exception ex)
            {
                return new ErrorResponse<List<Expense>>("EE", message: ex.Message);
            }
        }
    }
}