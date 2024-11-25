using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fresh_Sense.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeRole { get; set; }

        [ForeignKey("Id")]
        [StringLength(450)]

        public string Id { get; set; }
    }
}
