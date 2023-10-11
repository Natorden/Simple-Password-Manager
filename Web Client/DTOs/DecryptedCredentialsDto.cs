using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Client.DTOs;

public sealed record DecryptedCredentialsDto
{
    public int? Id { get; set; }
    public string? Sitename { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
