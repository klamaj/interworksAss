using API.DTOs;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AuthController : BaseApiController
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _config;
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IConfiguration config)
    {
        _config = config;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;

    }

    // DoLogin
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto val)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == val.Email.ToLower());
        
        if (user is null) return Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, val.Password, false);

        if (!result.Succeeded) return Unauthorized();

        return new UserDto
        {
            Email = user.Email.ToLower(),
            Token = _tokenService.CreateToken(user)
        };
    }

}
