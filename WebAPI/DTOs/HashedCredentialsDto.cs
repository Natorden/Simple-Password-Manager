namespace WebAPI.DTOs;

public sealed record HashedCredentialsDto
{
    public string? Sitename { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
