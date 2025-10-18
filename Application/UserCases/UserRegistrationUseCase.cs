
using Domain.Ports;
using Domain.Ports.Repositories;
using Domain.Services;

namespace Application.UserCases
{
    public class UserRegistrationUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserRegistrationService _userRegistrationService;
        private readonly IUnitOfWork _unitOfWork;

        public UserRegistrationUseCase(
            IUserRepository userRepository,
            UserRegistrationService userRegistrationService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userRegistrationService = userRegistrationService;
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterUserAsync(string username, string password, string email)
        {
            var user = await _userRegistrationService.CreateUserAsync(username, password, email);
            await _userRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
