using Microsoft.AspNetCore.Identity;

namespace IS_BuildFirm.Models
{
    public class User:IdentityUser
    {
        public int Age { get; set; }
    }
}
