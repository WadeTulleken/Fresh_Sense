using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public string SupplierPhoneNo { get; set; }

        [Required]
        public string SupplierEmail { get; set; }
    }
}
