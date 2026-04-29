using System;

namespace StoreBackend.Dto.user;

public class UserDto
{
    public Guid ExternalId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Name{get; set;}
}
