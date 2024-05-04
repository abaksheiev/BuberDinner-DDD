using BS.Application.Authentication.Common;
using BS.Contracts.Authentication;
using Mapster;

namespace BS.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
