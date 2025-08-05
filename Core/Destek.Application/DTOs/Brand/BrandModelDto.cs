namespace Destek.Application.DTOs.Brand
{
    public class BrandModelDto
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
