using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.WarehouseRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Warehouse.Create
{
    public class CreateWarehouseCommandHandler(IWarehouseWriteRepository warehouseWriteRepository, IWarehouseReadRepository warehouseReadRepository) : IRequestHandler<CreateWarehouseCommandRequest, CreateWarehouseCommandResponse>
    {
        public async Task<CreateWarehouseCommandResponse> Handle(CreateWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = warehouseReadRepository.GetWhere(x => x.Name == request.Name && x.Location==request.Location && !x.IsDeleted && x.DepartmentId==Guid.Parse(request.DepartmentId)).FirstOrDefault();
            if(isExist!=null)
            {
                return new()
                {
                    Message = $"{request.Name} deposu daha önce oluşturulmuş. Aynı isimde tekrar eklenilmez.",
                    Succeeded = false,
                };
            }
            await warehouseWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                DepartmentId = Guid.Parse(request.DepartmentId),
                Location = request.Location

            });
            if (await warehouseWriteRepository.SaveAsync() == 1)
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
