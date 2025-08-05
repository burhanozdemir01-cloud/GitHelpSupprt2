namespace Destek.Application.DTOs.Warehouse
{
    public class WarehouseModelDto
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
