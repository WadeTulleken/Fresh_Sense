using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class RequestForQuotation
    {
        [Key]
        public int RFQId {get; set;}
        
        [Required]
        public string FridgeModel {get; set;}

        [Required]
        public DateTime QuotationDeadline {get; set;}

        [Required]
        public int SupplierId {get; set;}

        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set;}
    }
}
