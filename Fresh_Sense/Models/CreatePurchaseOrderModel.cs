using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class CreatePurchaseOrderModel
    {
        [Key]
        public int POId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set; }

        [Required]
        public string FridgeModel { get; set; }

        [Required]
        public int POQuantity { get; set; }

        [Required]
        public DateTime PODateRequired { get; set; }

    }
}
