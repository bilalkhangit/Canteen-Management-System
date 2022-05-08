
using Microsoft.AspNetCore.Identity;

namespace Canteen_Management_System.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
