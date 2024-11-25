using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }


        [Required(ErrorMessage = "Business Name is required.")]
        [StringLength(100, ErrorMessage = "Business Name cannot exceed 100 characters.")]
        public string BusinessName { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; }

        [ForeignKey("Id")]
        [StringLength(450)]

        public string Id { get; set; }
    }
}
