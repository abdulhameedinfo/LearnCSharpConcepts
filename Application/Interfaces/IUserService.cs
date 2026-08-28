using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
    Task<User> RegisterAsync(UserRegisterDto request);
    Task<TokenResponseDto?> LoginAsync(UserLoginDto request);
    Task<TokenResponseDto?> RefreshTokenAsync(TokenResponseDto request);
    Task LogoutAsync(string username);
    Task UpdateUserAsync(string username, UserUpdateDto request);
    Task DeleteUserAsync(string username);
}