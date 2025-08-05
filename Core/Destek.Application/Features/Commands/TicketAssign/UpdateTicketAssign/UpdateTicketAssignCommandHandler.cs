using Destek.Application.Repositories.TicketAssignRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketAssign.UpdateTicketAssign
{
    public class UpdateTicketAssignCommandHandler(ITicketAssignWriteRepository ticketAssignWriteRepository, ITicketAssignReadRepository ticketAssignReadRepository) : IRequestHandler<UpdateTicketAssignCommandRequest, UpdateTicketAssignCommandResponse>
    {
        public async Task<UpdateTicketAssignCommandResponse> Handle(UpdateTicketAssignCommandRequest request, CancellationToken cancellationToken)
        {
            d.TicketAssign ticketAssign = await ticketAssignReadRepository.GetByIdAsync(request.Id);
            if (request.IsJobCount)
                ticketAssign.JobCount = request.JobCountOrExtraPoint;
            else
                ticketAssign.ExtraPoint = request.JobCountOrExtraPoint;
            await ticketAssignWriteRepository.SaveAsync();
            return new();
        }
    }
}
