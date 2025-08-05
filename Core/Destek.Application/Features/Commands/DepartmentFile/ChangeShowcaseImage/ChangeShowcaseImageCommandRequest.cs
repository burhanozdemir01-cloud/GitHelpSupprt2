using MediatR;

namespace Destek.Application.Features.Commands.DepartmentFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
    {
        public string ImageId { get; set; }
        public string DepartmentId { get; set; }
    }
}
