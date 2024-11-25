using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class ProcessQuotation
    {
        [Key]
        public int QuotationID { get; set; }

        [Required]
        public int SupplierId {get; set;}

        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set;}

        [Required]
        public DateTime QuotationDeadline {get; set;}

        [Required]
        public string QuotationStatus {get; set;} //Pending, Accepted, Rejected
    }
}
