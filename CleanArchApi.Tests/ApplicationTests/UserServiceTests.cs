
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Application.Services;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Domain.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace CleanArchApi.Tests.ApplicationTests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _tokenServiceMock = new Mock<ITokenService>();
        _userService = new UserService(_userRepoMock.Object, _tokenServiceMock.Object);
    }

    [Fact]
    public async Task RegisterAsync_ShouldHashPassword_AndSaveUser()
    {
        // Arrange
        var dto = new UserRegisterDto("testuser", "test@email.com", "Password123!");

        // Act
        var result = await _userService.RegisterAsync(dto);

        // Assert
        result.Username.Should().Be(dto.Username);
        result.PasswordHash.Should().NotBe(dto.Password); // Password must be hashed
        _userRepoMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        _userRepoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task LoginAsync_WithValidCredentials_ShouldReturnTokens()
    {
        // Arrange
        var password = "CorrectPassword";
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User { Username = "testuser", PasswordHash = hashedPassword };
        
        var loginDto = new UserLoginDto("testuser", password);

        _userRepoMock.Setup(r => r.GetByUsernameAsync("testuser")).ReturnsAsync(user);
        _tokenServiceMock.Setup(t => t.CreateToken(user)).Returns("access_token");
        _tokenServiceMock.Setup(t => t.GenerateRefreshToken()).Returns("refresh_token");

        // Act
        var result = await _userService.LoginAsync(loginDto);

        // Assert
        result.Should().NotBeNull();
        result!.AccessToken.Should().Be("access_token");
        result.RefreshToken.Should().Be("refresh_token");
        
        user.RefreshToken.Should().Be("refresh_token"); // Check if user was updated with refresh token
        _userRepoMock.Verify(r => r.UpdateAsync(user), Times.Once);
    }

    [Fact]
    public async Task LoginAsync_WithWrongPassword_ShouldReturnNull()
    {
        // Arrange
        var user = new User { Username = "testuser", PasswordHash = BCrypt.Net.BCrypt.HashPassword("RealPassword") };
        var loginDto = new UserLoginDto("testuser", "WrongPassword");

        _userRepoMock.Setup(r => r.GetByUsernameAsync("testuser")).ReturnsAsync(user);

        // Act
        var result = await _userService.LoginAsync(loginDto);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task LogoutAsync_ShouldClearRefreshToken()
    {
        // Arrange
        var user = new User { Username = "testuser", RefreshToken = "existing_token" };
        _userRepoMock.Setup(r => r.GetByUsernameAsync("testuser")).ReturnsAsync(user);

        // Act
        await _userService.LogoutAsync("testuser");

        // Assert
        user.RefreshToken.Should().BeNull();
        _userRepoMock.Verify(r => r.UpdateAsync(user), Times.Once);
    }
}