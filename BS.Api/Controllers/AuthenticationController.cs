using BS.Application.Authentication.Commands.Register;
using BS.Application.Authentication.Common;
using BS.Application.Authentication.Queries.Login;
using BS.Contracts.Authentication;
using BS.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BS.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController: ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(
            IMediator mediator,
            IMapper mapper)

        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest requst)
        {
            var command = _mapper.Map<RegisterCommand>(requst);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                    authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                    errors => Problem(errors)
                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send<ErrorOr<AuthenticationResult>>(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description
                    );
            }

            return authResult.Match(
                   authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                   errors => Problem(errors));
        }
    }
}
