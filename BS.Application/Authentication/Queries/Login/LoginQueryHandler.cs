using BS.Application.Authentication.Common;
using BS.Application.Common.Interfaces.Authentication;
using BS.Application.Persistence;
using BS.Domain.Common.Errors;
using BS.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BS.Application.Authentication.Queries.Login
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            // 1. Validate the user does exist
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // 3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                   user,
                   token
           );
        }
    }
}
