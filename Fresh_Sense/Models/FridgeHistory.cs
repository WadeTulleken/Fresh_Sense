using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fresh_Sense.Models
{
    public class FridgeHistory
    {
        [Key]
        public int FidgeHistoryID { get; set; }
        [ForeignKey("FaultReportID")]
        public int FaultReportID { get; set; }
        [ForeignKey("FridgeServiceID")]
        public int FridgeServiceID { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

    }
}
