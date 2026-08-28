using Domain.Entities;
using System.Security.Claims;

namespace Application.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}