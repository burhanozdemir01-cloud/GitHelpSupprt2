using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsActive { get; set; }

    }
}
