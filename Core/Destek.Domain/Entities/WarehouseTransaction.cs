using Destek.Domain.Entities.Common;
using Destek.Domain.Enums;

namespace Destek.Domain.Entities
{
    public class WarehouseTransaction:BaseEntity
    {
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public Guid? TicketId { get; set; }
        public TransactionType TransactionType { get; set; } // "Ekleme" veya "Çıkarma"

       
        public Ticket Ticket { get; set; }
    }
}
