using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class ProcessDeliveryNoteModel
    {
        [Key]
        public int DNId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set; }

        [Required]
        public string FridgeModel { get; set; }

        [Required]

        public int DNQuantity { get; set; }

        [Required]
        public string DNStatus { get; set; } //Pending, Approved, Denied
    }
}
