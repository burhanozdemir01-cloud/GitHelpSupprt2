using Destek.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string SerialNumber { get; set; }
        public string WarehouseCategoryId { get; set; }
        public string BrandId { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
  
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
