using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.SubCategory.UpdateSubCategory
{
    public class UpdateSubCategoryCommandRequest:IRequest<UpdateSubCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
