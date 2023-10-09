namespace Data_Access_Layer.Models;

public sealed record HashedCredentials
{
    public string? Sitename { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}