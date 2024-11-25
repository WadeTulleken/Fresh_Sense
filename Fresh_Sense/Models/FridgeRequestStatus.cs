using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class FridgeRequestStatus
    {
        [Key]
        public int FridgeRequestStatusID { get; set; }
        [Required]
        public string StatusForFridgeRequest { get; set; }
        [ForeignKey("RequestID")]
        public int RequestID { get; set; }
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }

        [ForeignKey("AssetID")]
        public int AssetID { get; set; }
    }
}
