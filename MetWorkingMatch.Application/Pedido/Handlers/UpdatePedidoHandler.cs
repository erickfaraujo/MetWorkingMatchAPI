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
    public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, BaseResponse<PedidoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdatePedidoHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PedidoResponse>> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PedidoResponse>();

            var pedido = _dbContext.PedidosMatch
                            .Include(p => p.IdStatusSolicitacao)
                            .Where(p => p.IdUserSolicitante == request.UpdateRequest.IdUserSolicitante)
                            .Where(p => p.IdUserAprovador == request.UpdateRequest.IdUserAprovador);

            if (!pedido.Any())
            {
                response.SetValidationErrors(new[] { "Pedido de Match não encontrado" });
            }
            else
            {
                var pedidoLista = pedido.ToList();

                if (!pedidoLista[0].IdStatusSolicitacao.Id.Equals(1))
                {
                    response.SetValidationErrors(new[] { "Pedido de Match já respondido" });
                }
                else
                {
                    pedidoLista[0].IdStatusSolicitacao = await _dbContext.StatusPedido.FindAsync((request.UpdateRequest.Action));
                    pedidoLista[0].DataAceite = System.DateTime.Now;

                    if (request.UpdateRequest.Action == 2)
                    {
                        Match match = new Match
                        {
                            IdUser = request.UpdateRequest.IdUserSolicitante,
                            IdAmigo = request.UpdateRequest.IdUserAprovador,
                            dataConexao = System.DateTime.Now
                        };

                        Match matchAmigo = new Match
                        {
                            IdUser = request.UpdateRequest.IdUserAprovador,
                            IdAmigo = request.UpdateRequest.IdUserSolicitante,
                            dataConexao = System.DateTime.Now
                        };

                        await _dbContext.Matches.AddAsync(match);
                        await _dbContext.Matches.AddAsync(matchAmigo);

                        _dbContext.PedidosMatch.Remove(pedidoLista[0]);
                    }

                    await _dbContext.SaveChangesAsync(cancellationToken);

                    response.SetIsOk(null);
                }
            }

            return response;
        }
    }
}
