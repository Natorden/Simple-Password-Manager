namespace Data_Access_Layer.Models;

public sealed record HashedCredentials
{
    public int? Id { get; set; }
    public byte[]? Sitename { get; set; }
    public byte[]? Username { get; set; }
    public byte[]? Password { get; set; }
}