using Microsoft.AspNetCore.Identity;

namespace Fresh_Sense.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNum { get; set; }
    }
}
