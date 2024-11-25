using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fresh_Sense.Models
{
    public class ProcessPurchaseRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Suppliers Supplier { get; set; }

        [Required]
        public string PRFridgeRequested { get; set; }

        [Required]
        public string RequestStatus {get; set;} //Pending, Approved, Declined
        }
    }

