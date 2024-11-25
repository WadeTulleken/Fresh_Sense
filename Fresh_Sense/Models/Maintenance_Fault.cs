using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class Maintenance_Fault
    {
        [Key]
        public int Mf_Id { get; set; }
        [Required]
        public string TechnicianAllocation { get; set; }
        [Required]
        public string FridgeModel { get; set; }
        [Required]
        public string DateReported { get; set; }
        [Required]
        public string Status { get; set; }
        public string FaultDesc { get; set; }

    }
}
