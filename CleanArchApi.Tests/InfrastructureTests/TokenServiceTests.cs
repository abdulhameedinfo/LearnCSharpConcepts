using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanArchApi.Domain.Entities;
using Microsoft.Extensions.Configuration;
using CleanArchApi.Infrastructure.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace CleanArchApi.Tests.InfrastructureTests;

public class TokenServiceTests
{
    private readonly Mock<IConfiguration> _configMock;
    private readonly TokenService _tokenService;
    private const string TestKey = "super_secret_key_that_is_long_enough_123!";

    public TokenServiceTests()
    {
        _configMock = new Mock<IConfiguration>();
        
        // Setup configuration mock
        _configMock.Setup(c => c["Jwt:Key"]).Returns(TestKey);
        _configMock.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
        _configMock.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");

        _tokenService = new TokenService(_configMock.Object);
    }

    [Fact]
    public void CreateToken_ShouldReturnValidJwt_WithCorrectClaims()
    {
        // Arrange
        var user = new User { Username = "testuser", Email = "test@example.com" };

        // Act
        var token = _tokenService.CreateToken(user);

        // Assert
        token.Should().NotBeNullOrEmpty();
        
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        jwtToken.Claims.Should().Contain(c => c.Type == ClaimTypes.Name && c.Value == user.Username);
        jwtToken.Claims.Should().Contain(c => c.Type == ClaimTypes.Email && c.Value == user.Email);
        jwtToken.Issuer.Should().Be("TestIssuer");
    }

    [Fact]
    public void GenerateRefreshToken_ShouldReturnLongRandomString()
    {
        // Act
        var token1 = _tokenService.GenerateRefreshToken();
        var token2 = _tokenService.GenerateRefreshToken();

        // Assert
        token1.Should().NotBeNullOrEmpty();
        token1.Should().NotBe(token2); // Should be unique
        token1.Length.Should().BeGreaterThan(20);
    }
}