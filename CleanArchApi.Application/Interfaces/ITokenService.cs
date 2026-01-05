using CleanArchApi.Domain.Entities;
using System.Security.Claims;

namespace CleanArchApi.Application.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}