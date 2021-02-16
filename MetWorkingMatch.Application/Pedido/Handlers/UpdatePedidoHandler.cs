using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, PedidoResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdatePedidoHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PedidoResponse> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            var pedidoRequest = _mapper.Map<PedidoMatch>(request.UpdateRequest);

            var pedido = _dbContext.PedidosMatch
                            .Include(p => p.IdStatusSolicitacao)
                            .Where(p => p.IdUserSolicitante == request.UpdateRequest.IdUserSolicitante)
                            .Where(p => p.IdUserAprovador == request.UpdateRequest.IdUserAprovador)
                            .ToList();

            if (request.UpdateRequest.Action == 2)
            {
                pedido[0].IdStatusSolicitacao = await _dbContext.StatusPedido.FindAsync(2);
                
            }
            else if (request.UpdateRequest.Action == 3)
            {
                pedido[0].IdStatusSolicitacao = await _dbContext.StatusPedido.FindAsync(3);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PedidoResponse>(pedidoRequest);
        }
    }
}
