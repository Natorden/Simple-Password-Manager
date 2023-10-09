namespace Web_Client.DTOs;

public sealed record HashedCredentialsDto
{
    public byte[]? Sitename { get; set; }
    public byte[]? Username { get; set; }
    public byte[]? Password { get; set; }
}
