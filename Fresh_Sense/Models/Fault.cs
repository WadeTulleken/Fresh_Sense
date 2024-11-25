using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class Fault
    {
        [Key]
        public int faultID { get; set; }

        [Required]
        public string fridgeModel { get; set; }

        [Required]
        public string faultType { get; set; }

        public string faultDescription { get; set; }
        public string? Status { get; set; } // Make Status nullable

    }
}
