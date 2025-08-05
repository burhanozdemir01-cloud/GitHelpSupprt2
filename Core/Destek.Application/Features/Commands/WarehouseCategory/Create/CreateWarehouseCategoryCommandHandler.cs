using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;

namespace Destek.Application.Features.Commands.WarehouseCategory.Create
{
    public class CreateWarehouseCategoryCommandHandler(IWarehouseCategoryWriteRepository warehouseCategoryWriteRepository,IWarehouseCategoryReadRepository warehouseCategoryReadRepository) : IRequestHandler<CreateWarehouseCategoryCommandRequest, CreateWarehouseCategoryCommandResponse>
    {
        public async Task<CreateWarehouseCategoryCommandResponse> Handle(CreateWarehouseCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist = warehouseCategoryReadRepository.GetWhere(x => x.Name == request.Name && !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId)).FirstOrDefault();
            if (isExist != null)
            {
                return new()
                {
                    Message = $"{request.Name} kategorisi daha önce oluşturulmuş. Aynı isimde tekrar eklenilmez.",
                    Succeeded = false,
                };
            }
            await warehouseCategoryWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                DepartmentId = Guid.Parse(request.DepartmentId)

            });
            if (await warehouseCategoryWriteRepository.SaveAsync() == 1)
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
