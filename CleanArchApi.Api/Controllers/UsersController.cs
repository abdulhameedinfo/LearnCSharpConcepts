using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CleanArchApi.Application.DTOs;
using CleanArchApi.Application.Interfaces;
using CleanArchApi.Domain.Entities;
using CleanArchApi.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
// ... existing code ...
namespace CleanArchApi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserRegisterDto request)
    {
        var user = await userService.RegisterAsync(request);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserLoginDto request)
    {
        var result = await userService.LoginAsync(request);
        if (result == null) return BadRequest("Invalid credentials.");
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(TokenResponseDto request)
    {
        var result = await userService.RefreshTokenAsync(request);
        if (result == null) return BadRequest("Invalid refresh token.");
        return Ok(result);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await userService.LogoutAsync(User.Identity!.Name!);
        return Ok();
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser(UserUpdateDto request)
    {
        try 
        {
            await userService.UpdateUserAsync(User.Identity!.Name!, request);
            return NoContent();
        }
        catch { return NotFound(); }
    }

    [Authorize]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser()
    {
        try
        {
            await userService.DeleteUserAsync(User.Identity!.Name!);
            return NoContent();
        }
        catch { return NotFound(); }
    }
}