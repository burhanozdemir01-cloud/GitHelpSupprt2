namespace Destek.Application.Features.Queries.WarehouseCategory.GetById
{
    public class GetWarehouseCategoryIdQueryResponse
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
