namespace WebAPI.DTOs;

public sealed record HashedCredentialsDto
{
    public int? Id { get; set; }
    public byte[]? Sitename { get; set; }
    public byte[]? Username { get; set; }
    public byte[]? Password { get; set; }
}
//TODO should this be string of byte array 