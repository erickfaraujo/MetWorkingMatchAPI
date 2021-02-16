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
    public class DeletePedidoHandler : IRequestHandler<DeletePedidoCommand, PedidoResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeletePedidoHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PedidoResponse> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = _dbContext.PedidosMatch
                                .Where(p => p.IdUserSolicitante == request.DeleteRequest.IdUserSolicitante)
                                .Where(p => p.IdUserAprovador == request.DeleteRequest.IdUserAprovador)
                                .ToList();
            
            _dbContext.PedidosMatch.Remove(pedido[0]);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PedidoResponse>(pedido);
        }
    }
}
