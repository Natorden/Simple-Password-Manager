﻿using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.DTOs.Converters;
using WebAPI.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    private readonly JWT_Helper _jwtHelper;

    public LoginController(IUserRepo userRepo, IConfiguration configuration)
    {
        _userRepo = userRepo;
        _jwtHelper = new JWT_Helper(configuration);
    }

    // POST api/login
    [HttpPost]
    public async Task<ActionResult<int>> PostAsync([FromBody] UserDto userDto)
    {
        if (userDto.Password == null || userDto.Username == null)
        {
            return BadRequest("Username or Password cannot be null");
        }

        var user = DtoConverter<UserDto, User>.From(userDto);
        Guid? returnedId = await _userRepo.LoginAsync(user);
        if ( returnedId.HasValue && returnedId.Value != Guid.Empty)
        {
            string jwtToken = _jwtHelper.GenerateToken(userDto);
            Response.Cookies.Append("X-Access-Token", jwtToken,
                new CookieOptions() {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(_jwtHelper.GetTokenMinutesDuration())
                });

            return Ok(returnedId);
        }
        else
        {
            return NotFound("Invalid username or password");
        }
    }


}
