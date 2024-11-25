using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class FridgeInventory
    {
        [Key]
        public int FridgeInventoryID { get; set; }

        [Required]
        public string FridgeMake { get; set; }

        [Required]
        public string FridgeModel { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string CustomerName { get; set; }
    }
}

   

