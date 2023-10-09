namespace Web_Client.DTOs;

public sealed record HashedCredentialsDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
