using Destek.Application.Repositories.BrandRepo;
using Destek.Application.Repositories.ProductRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandHandler(IProductWriteRepository productWriteRepository,IProductReadRepository productReadRepository) : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = productReadRepository.GetWhere(x => x.Name == request.Name && !x.IsDeleted && x.BrandId == Guid.Parse(request.BrandId) && x.WarehouseCategoryId==Guid.Parse(request.WarehouseCategoryId)).FirstOrDefault();
            if (isExist != null)
            {
                return new()
                {
                    Message = $"{request.Name} Ürünü zaten eklenmiş. Aynı isimde tekrar eklenilmez.",
                    Succeeded = false,
                };
            }
            await productWriteRepository.AddAsync(new()
            {
               
                WarehouseCategoryId=Guid.Parse(request.WarehouseCategoryId),
                BrandId=Guid.Parse(request.BrandId),
                Name = request.Name,
                Barcode= request.SerialNumber,
                SerialNumber=request.SerialNumber,
           
                UnitOfMeasureType=request.UnitOfMeasureType,


            });
            if (await productWriteRepository.SaveAsync() == 1)
                return new()
                {
                    Message = $"{request.Name} Başarılı bir şekilde eklendi.",
                    Succeeded = true,
                };

            return new()
            {
                Message = "Hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
                Succeeded = false,
            };
        }
    }
}
