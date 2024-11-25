using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresh_Sense.Models
{
    public class CustomerFridges
    {
        [Key]
        public int CustomerFridgesID { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        public string LastService { get; set; }
        [Required]
        public string NextMaintananceDate { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        [ForeignKey("FridgeServiceID")]
        public int FridgeServiceID { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
    }
        
}
