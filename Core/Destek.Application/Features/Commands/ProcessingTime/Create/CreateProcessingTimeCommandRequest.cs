using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.ProcessingTime.Create
{
    public class CreateProcessingTimeCommandRequest:IRequest<CreateProcessingTimeCommandResponse>
    {
        public string SubCategoryId { get; set; }
        public int Minute { get; set; }
    }
}
