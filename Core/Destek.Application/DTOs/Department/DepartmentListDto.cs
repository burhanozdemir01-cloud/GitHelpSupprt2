using d=Destek.Domain.Entities;
namespace Destek.Application.DTOs.Department
{
    public class DepartmentListDto
    {
        public IList<d.Department> Departments { get; set; }
    }
}
