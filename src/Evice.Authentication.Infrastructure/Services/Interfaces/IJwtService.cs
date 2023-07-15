using Evice.Authentication.Domain.AggregatesModel.LoginAggregate;

namespace Evice.Authentication.Infrastructure.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateEncodedToken(UserInfoToken userInfoToken, int expirationInSeconds = 120);
    }
}