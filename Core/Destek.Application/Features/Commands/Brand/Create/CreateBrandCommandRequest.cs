using MediatR;

namespace Destek.Application.Features.Commands.Brand.Create
{
    public class CreateBrandCommandRequest:IRequest<CreateBrandCommandResponse>
    {
        public string DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
