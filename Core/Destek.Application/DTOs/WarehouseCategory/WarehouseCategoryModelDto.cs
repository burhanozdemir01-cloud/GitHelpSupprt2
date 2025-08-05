namespace Destek.Application.DTOs.WarehouseCategory
{
    public class WarehouseCategoryModelDto
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
