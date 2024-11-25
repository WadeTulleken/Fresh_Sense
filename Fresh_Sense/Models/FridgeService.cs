using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresh_Sense.Models
{
    public class FridgeService
    {
        [Key]
        public int FridgeServiceID { get; set; }
        [Required]
        public int SerielNumber { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public string Cost { get; set; }
        [ForeignKey("FridgeHistoryID")]
        public int FridgeHistoryID { get; set; }
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
    }
}
