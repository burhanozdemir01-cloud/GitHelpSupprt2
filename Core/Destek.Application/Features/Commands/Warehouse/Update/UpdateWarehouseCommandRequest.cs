using MediatR;

namespace Destek.Application.Features.Commands.Warehouse.Update
{
    public class UpdateWarehouseCommandRequest:IRequest<UpdateWarehouseCommandResponse>
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
