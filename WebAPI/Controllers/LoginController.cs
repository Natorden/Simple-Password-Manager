﻿using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUserRepo _userRepo;

    public LoginController(IUserRepo userRepo, IConfiguration configuration)
    {
        _userRepo = userRepo;
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
        int? returnedId = await _userRepo.LoginAsync(user);
        if (returnedId.HasValue && returnedId.Value != -1)
        {
            return Ok(returnedId);
        }
        else
        {
            return NotFound("Invalid username or password");
        }
    }


}