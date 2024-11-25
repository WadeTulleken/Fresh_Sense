using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresh_Sense.Models
{
    public class PurchaseRequest
    {
        [Key]
        public int PurchaseRequestId { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Quantity { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        
    }
}
