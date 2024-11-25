using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class FridgeAllocation
    {
        [Key]
        public int FAId { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]

        public string CustomerName { get; set; }

     

    }
}
