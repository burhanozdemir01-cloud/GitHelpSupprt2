using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.SubCategory.CreateSubCategory
{
    public class CreateSubCategoryCommandRequest:IRequest<CreateSubCategoryCommandResponse>
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
    }
}
