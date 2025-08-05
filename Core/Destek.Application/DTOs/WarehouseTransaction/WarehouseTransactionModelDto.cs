using Destek.Domain.Enums;

namespace Destek.Application.DTOs.WarehouseTransaction
{
    public class WarehouseTransactionModelDto
    {

        public string Id { get; set; }
    
        public string ProductId { get; set; }
        public string TicketId { get; set; }
        public string WarehouseName { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public decimal Quantity { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
