using Destek.Domain.Enums;
using MediatR;

namespace Destek.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        //public string Barcode { get; set; }
        public string SerialNumber { get; set; }
        public string WarehouseCategoryId { get; set; }    
        public string BrandId { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
      
    }
}
