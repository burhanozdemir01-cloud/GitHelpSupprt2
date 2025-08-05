namespace Destek.Application.Features.Queries.Brand.GetById
{
    public class GetBrandIdQueryResponse
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
