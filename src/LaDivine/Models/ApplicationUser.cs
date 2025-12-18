using Microsoft.AspNetCore.Identity;

namespace LaDivine.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Optional: link user to a site (ResponsableSite)
        public Guid? SiteId { get; set; }
        public Site Site { get; set; }

        // Additional profile fields can be added here later
    }
}