namespace Destek.Application.Features.Queries.Warehouse.GetById
{
    public class GetWarehouseIdQueryResponse
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
