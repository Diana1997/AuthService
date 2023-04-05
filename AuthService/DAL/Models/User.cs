using Microsoft.AspNetCore.Identity;

namespace AuthService.DAL.Models
{
    public class User : IdentityUser
    {
        public string Firstname { set; get; }
        public string Lastname { set; get; }
    }
}