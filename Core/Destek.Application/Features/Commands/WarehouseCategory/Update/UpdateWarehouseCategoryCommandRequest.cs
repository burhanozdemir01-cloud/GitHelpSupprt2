using MediatR;

namespace Destek.Application.Features.Commands.WarehouseCategory.Update
{
    public class UpdateWarehouseCategoryCommandRequest:IRequest<UpdateWarehouseCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
