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
    public class DeletePedidoHandler : IRequestHandler<DeletePedidoCommand, BaseResponse<PedidoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeletePedidoHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PedidoResponse>> Handle(DeletePedidoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PedidoResponse>();
            var pedido = _dbContext.PedidosMatch
                                .Where(p => p.IdUserSolicitante == request.DeleteRequest.IdUserSolicitante)
                                .Where(p => p.IdUserAprovador == request.DeleteRequest.IdUserAprovador);

            if (!pedido.Any())
            {
                response.SetValidationErrors(new[] { "Pedido de Match não encontrado" });
            }
            else
            {
                var pedidoLista = pedido.ToList();
                _dbContext.PedidosMatch.Remove(pedidoLista[0]);
                await _dbContext.SaveChangesAsync(cancellationToken);
                response.SetIsOk(null);
            }

            return response;
        }
    }
}
