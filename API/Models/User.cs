using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class User : IdentityUser<int>
{
    public ICollection<UserRoles> UserRoles { get; set; }
}
