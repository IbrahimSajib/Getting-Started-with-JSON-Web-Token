using JSON_Web_Token.Models;

namespace JSON_Web_Token.Services
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterVM model);
        Task<bool> Login(LoginVM model);
        string GenerateTokenString(LoginVM model);
    }
}