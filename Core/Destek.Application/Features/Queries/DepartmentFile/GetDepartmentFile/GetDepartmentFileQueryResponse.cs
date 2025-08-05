namespace Destek.Application.Features.Queries.DepartmentFile.GetDepartmentFile
{
    public class GetDepartmentFileQueryResponse
    {
        public string Path { get; set; }
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string DepartmentId { get; set; }
    }
}
