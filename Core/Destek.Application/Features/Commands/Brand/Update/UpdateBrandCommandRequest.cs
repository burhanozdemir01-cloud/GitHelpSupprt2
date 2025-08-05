using MediatR;

namespace Destek.Application.Features.Commands.Brand.Update
{
    public class UpdateBrandCommandRequest:IRequest<UpdateBrandCommandResponse>
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
