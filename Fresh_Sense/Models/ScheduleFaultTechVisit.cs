using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class ScheduleFaultTechVisit
    {
        [Key]
        public int vistID { get; set; }
        [Required]
        public string visitDate { get; set; }
        [Required]
        public string visitTime { get; set; }
        public string notes { get; set; }

        
    }
}
