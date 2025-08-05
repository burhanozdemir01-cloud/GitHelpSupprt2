using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Warehouse.Create
{
    public class CreateWarehouseCommandRequest:IRequest<CreateWarehouseCommandResponse>
    {
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
