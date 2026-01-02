namespace CleanArchApi.Application.DTOs;

public record UserRegisterDto(string Username, string Email, string Password);
public record UserLoginDto(string Username, string Password);
public record UserUpdateDto(string Email);
public record TokenResponseDto(string AccessToken, string RefreshToken);