using Microsoft.AspNetCore.Identity;

namespace DriveX.Domain.Entities;

public class AppUser : IdentityUser
{
    /// <summary>
    /// User full name
    /// </summary>
    public string FIO { get; set; }
}
