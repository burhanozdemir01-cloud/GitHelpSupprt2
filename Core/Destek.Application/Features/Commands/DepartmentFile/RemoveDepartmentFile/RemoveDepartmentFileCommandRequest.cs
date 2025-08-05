using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.DepartmentFile.RemoveDepartmentFile
{
    public class RemoveDepartmentFileCommandRequest:IRequest<RemoveDepartmentFileCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
