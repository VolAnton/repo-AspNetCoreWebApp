using IdentityModel.Client;

namespace Timesheets.API.Authentication
{
    public interface IUserService
    {
        //string Authenticate(string user, string password);        // замена возвращаемого значения

        TokenResponse Authenticate(string user, string password);

        //string RefreshToken(string token); // замена возвращаемого значения

        TokenResponse RefreshToken(string token);

    }

}
