using BS.Domain.Entities;

namespace BS.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
