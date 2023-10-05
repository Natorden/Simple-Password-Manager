namespace WebAPI.DTOs;

public sealed record UserDto
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}