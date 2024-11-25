using Fresh_Sense.Areas.Identity;

namespace Fresh_Sense.Models
{
    public class ProfileViewModel
    {
        
        public ApplicationUser ApplicationUser { get; set; }
        public Customer Customer { get; set; }
    }
}
