using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.DTOs;
using WebAPI.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;
[Route("api/[controller]")]
public class PasswordVaultController : ControllerBase
{
    private readonly IPasswordVaultRepo _passwordVaultRepo;

    public PasswordVaultController(IPasswordVaultRepo passwordVaultRepo, IConfiguration configuration)
    {
        _passwordVaultRepo = passwordVaultRepo;
    }

    // GET api/PasswordVault/<guid>
    [HttpGet("{id}")]
    public async Task<ActionResult<PasswordVaultDto>> Get(Guid ownerGuid)
    {
        var vault = await _passwordVaultRepo.GetAsync(ownerGuid);
        return Ok(DtoConverter<PasswordVault, PasswordVaultDto>.From(vault));
    }

    // PUT api/PasswordVault/<guid>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid ownerGuid, [FromBody] PasswordVaultDto vaultDto)
    {
        if(ownerGuid != vaultDto.OwnerGuid)
        {
            return BadRequest();
        }


        var vault = DtoConverter<PasswordVaultDto, PasswordVault>.From(vaultDto);
        var result = await _passwordVaultRepo.UpdateAsync(ownerGuid, vault);

        if(!result)
        {
            // Something went wrong in the DAL and vault wasn't updated
            return BadRequest();
        }

        return NoContent();
    }

    }
}
