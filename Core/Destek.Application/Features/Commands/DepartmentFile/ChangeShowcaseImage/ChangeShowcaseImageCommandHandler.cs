using Destek.Application.Repositories.DepartmentFileRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Destek.Application.Features.Commands.DepartmentFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler(IDepartmentFileWriteRepository departmentFileWriteRepository) : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = departmentFileWriteRepository.Table
                      .Include(p => p.Departments)
                      .SelectMany(p => p.Departments, (pif, p) => new
                      {
                          pif,
                          p
                      });

            var data = await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.DepartmentId) && p.pif.Showcase);

            if (data != null)
                data.pif.Showcase = false;

            var image = await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
            if (image != null)
                image.pif.Showcase = true;

            await departmentFileWriteRepository.SaveAsync();

            return new();
        }
    }
}
