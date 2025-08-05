using MediatR;

namespace Destek.Application.Features.Commands.WarehouseCategory.Create
{
    public class CreateWarehouseCategoryCommandRequest:IRequest<CreateWarehouseCategoryCommandResponse>
    {
        public string DepartmentId { get; set; }
        public string Name { get; set; }

    }
}
