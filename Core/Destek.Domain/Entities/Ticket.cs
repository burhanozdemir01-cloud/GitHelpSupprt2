using Destek.Domain.Entities.Common;
using Destek.Domain.Entities.Identity;
using Destek.Domain.Enums;
namespace Destek.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool IsNew { get; set; }
        public string TraceNumber { get; set; }
        public string NormalizedTraceNumber { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid AppUserId { get; set; }
        public bool IsImportand { get; set; }
        public bool IsLocked { get; set; }
        public ImportanceLevel ImportanceLevel { get; set; }



        public SubCategory SubCategory { get; set; }
        public Department Department { get; set; }
        public ICollection<TicketFile> TicketFiles { get; set; }
        public ICollection<TicketAssign> TicketAssigns { get; set; }
        public ICollection<TicketLocked> TicketLockeds { get; set; }
        public ICollection<TicketUnnecessary> TicketUnnecessaries { get; set; }
        public ICollection<TicketTransaction> TicketTransactions { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<WarehouseTransaction> WarehouseTransactions { get; set; }
    }
}
