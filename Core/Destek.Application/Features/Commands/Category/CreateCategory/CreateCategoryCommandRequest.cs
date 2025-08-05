using Destek.Application.DTOs.Catgeory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
    {
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        //public CategoryAddDto CategoryAddDto { get; set; }
    }
}
