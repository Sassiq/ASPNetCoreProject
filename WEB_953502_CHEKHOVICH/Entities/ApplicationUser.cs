using Microsoft.AspNetCore.Identity;

namespace WEB_953502_CHEKHOVICH.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
