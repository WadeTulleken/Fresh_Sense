using Fresh_Sense.Areas.Identity;
using Fresh_Sense.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Fresh_Sense.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<FridgeRequest> FridgeRequests { get; set; }
        public DbSet<Maintenance_Fault> maintenance_Faults { get; set; }

        public DbSet<Schedule_MaintenanceVisit> scheduleMaintenanceVisits { get; set; }

        public DbSet<FridgeAllocation> fridgeAllocations { get; set; }
        public DbSet<ScheduleFaultTechVisit> scheduleFaultTechVisits { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

        public DbSet<CreatePurchaseOrderModel> PurchaseOrders { get; set; }

        public DbSet<ProcessDeliveryNoteModel> DeliveryNote { get; set; }

        public DbSet<ProcessQuotation> Quotations { get; set; }

        public DbSet<RequestForQuotation> RequestForQuotation {get; set;}

        public DbSet<ProcessPurchaseRequest> PurchaseRequestProcess {get; set;}

        public DbSet<FridgeInventory> FridgeInventory { get; set; }

        //public DbSet<CustomerFridgeAllocation> CustomerFridgeAllocations { get; set; }

        //public DbSet<PurchaseRequest> PurchaseRequests { get; set; }

        //public DbSet<MaintenanceFaultReport> MaintenanceFaultReports { get; set; }

        //public DbSet<ScheduleMaintenanceVisit> ScheduleMaintenanceVisits { get; set; }

        //public DbSet<ReportFault> FaultReports { get; set; }
        
        //public DbSet<FridgeRequest> FridgeRequests { get; set; }

        //public DbSet<FaultStatus> FaultStatuses { get; set; }

        //public DbSet<FridgeRequestStatus> FridgeRequsetStatuses { get; set; }

        //public DbSet<FaultTechVisitingScheduling> faultTechVisitingSchedulings { get; set; }
        //public DbSet<FridgeHistory> fridgeHistories { get; set; }
        //public DbSet<FridgeFault> fridgeFaults { get; set; }
        //public DbSet<FridgeService> fridgeServices { get; set; }
        //public DbSet<CustomerFridges> customerFridges { get; set; }

        public DbSet<Employee> Employees { get; set; }
        
    }
}
