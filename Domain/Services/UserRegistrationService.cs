using Domain.Exceptions;
using Domain.Models;
using Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserRegistrationService
    {
        private readonly IUserRepository _userRepository;
        public UserRegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(string username, string password, string email)
        {
            if (!await _userRepository.IsUsernameUniqueAsync(username))
            {
                throw new BusinessRuleValidationException("El nombre de usuario ya está en uso.");
            }
            if (!await _userRepository.IsEmailUniqueAsync(email))
            {
                throw new BusinessRuleValidationException("El correo electrónico ya está en uso.");
            }
            var user = User.Create(username, password, email);
            return user;
        }
    }
}
