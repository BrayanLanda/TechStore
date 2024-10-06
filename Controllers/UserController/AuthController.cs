using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.DTOs.UserDtos;
using TechStore.Interfaces;

namespace TechStore.Controllers.UserController
{
    public class AuthController : AuthControllerBase
{
    public AuthController(IAuthRepository authRepository) : base(authRepository)
    {
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authRepository.RegisterAsync(userRegisterDto);

        return CreatedAtAction(nameof(Register), new { username = result.Username }, result);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authRepository.LoginAsync(userLoginDto);

        return Ok(result);
    }
}
}