using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;

namespace CleanArchApi.Application.Services;

public class UserService(IUserRepository userRepository, ITokenService tokenService) : IUserService
{
    public async Task<User> RegisterAsync(UserRegisterDto request)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();
        return user;
    }

    public async Task<TokenResponseDto?> LoginAsync(UserLoginDto request)
    {
        var user = await userRepository.GetByUsernameAsync(request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;

        var token = tokenService.CreateToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        
        await userRepository.UpdateAsync(user);
        await userRepository.SaveChangesAsync();

        return new TokenResponseDto(token, refreshToken);
    }

    public async Task<TokenResponseDto?> RefreshTokenAsync(TokenResponseDto request)
    {
        var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        var username = principal.Identity?.Name;

        var user = await userRepository.GetByUsernameAsync(username!);
        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            return null;

        var newAccessToken = tokenService.CreateToken(user);
        var newRefreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await userRepository.UpdateAsync(user);
        await userRepository.SaveChangesAsync();

        return new TokenResponseDto(newAccessToken, newRefreshToken);
    }

    public async Task LogoutAsync(string username)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        if (user != null)
        {
            user.RefreshToken = null;
            await userRepository.UpdateAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateUserAsync(string username, UserUpdateDto request)
    {
        var user = await userRepository.GetByUsernameAsync(username) ?? throw new Exception("User not found");
        user.Email = request.Email;
        await userRepository.UpdateAsync(user);
        await userRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(string username)
    {
        var user = await userRepository.GetByUsernameAsync(username) ?? throw new Exception("User not found");
        await userRepository.DeleteAsync(user);
        await userRepository.SaveChangesAsync();
    }
}