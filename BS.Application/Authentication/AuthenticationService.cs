using BS.Application.Common.Interfaces.Authentication;
using BS.Application.Persistence;
using BS.Domain.Entities;

namespace BS.Application.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);

    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository; 

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // 1. Validate the user does exist
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given already exists.");
            }
            
            // 2. Validate the password is correct
            if (user.Password != password) {
                throw new Exception("Invalid password.");
            }
            
            // 3. Create JWT tokent
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(
                   user,
                   token
                );
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // 1. Validate the user doesn't exist
            if (_userRepository.GetUserByEmail(email) is not null) {
                throw new Exception("User with given already exists.");
            }
            // 2. Create user(generate unique ID) & Persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            // 3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                     user,
                    token
                );
        }
    }
}
