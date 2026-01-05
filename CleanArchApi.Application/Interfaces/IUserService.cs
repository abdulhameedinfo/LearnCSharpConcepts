using CleanArchApi.Application.DTOs;
using CleanArchApi.Domain.Entities;

namespace CleanArchApi.Application.Interfaces;

public interface IUserService
{
    Task<User> RegisterAsync(UserRegisterDto request);
    Task<TokenResponseDto?> LoginAsync(UserLoginDto request);
    Task<TokenResponseDto?> RefreshTokenAsync(TokenResponseDto request);
    Task LogoutAsync(string username);
    Task UpdateUserAsync(string username, UserUpdateDto request);
    Task DeleteUserAsync(string username);
}