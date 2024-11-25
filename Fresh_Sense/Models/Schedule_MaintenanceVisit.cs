using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class Schedule_MaintenanceVisit
    {
        [Key]
        public int ScheduleMaintenanceVisitID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string FridgeModel { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]

        public string TechnicianAllocation { get; set; }

        [Required]

        public string Notes { get; set; }

        
    }
}

   

