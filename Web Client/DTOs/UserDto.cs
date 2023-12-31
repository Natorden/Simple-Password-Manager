﻿namespace Web_Client.DTOs;

public sealed record UserDto
{
    public Guid? Guid { get; set; }
    public string? Username { get; set; }
    public byte[]? Password { get; set; }
}