using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class Role : IdentityRole<int>
{
    public ICollection<UserRoles> UserRoles { get; set; }
}
