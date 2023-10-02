namespace Data_Access_Layer.Models;

public sealed record User
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}