using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresh_Sense.Models
{
    public class FridgeRequest
    {
        [Key]
        public int RequsetID { get; set; }
        [Required]
        public string FridgeModel { get; set; }
        [Required]
        public string ReasonForRequest { get; set; }
        public string MoreAboutYourRequest { get; set; }
        public string? Status { get; set; } // Make Status nullable

    }
}
