using Destek.Application.Abstractions.Storage;
using Destek.Application.Repositories.DepartmentFileRepo;
using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using Destek.Domain.Enums;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.DepartmentFile.UploadDepartmentFile
{
    public class UploadDepartmentFileCommandHandler(IStorageService storageService, IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository, IDepartmentFileWriteRepository departmentFileWriteRepository) : IRequestHandler<UploadDepartmentFileCommandRequest, UploadDepartmentFileCommandResponse>
    {
        public async Task<UploadDepartmentFileCommandResponse> Handle(UploadDepartmentFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await storageService.UploadAsync("photo-images", request.Files);

            d.Department department = await departmentReadRepository.GetByIdAsync(request.Id);
            await departmentFileWriteRepository.AddRangeAsync(result.Select(r => new d.DepartmentFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                StorageType = StorageType.Local,
                Departments = new List<d.Department>() { department }
            }).ToList());

            await departmentFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
