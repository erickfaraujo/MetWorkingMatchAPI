using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Queries;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class GetPedidosRecebidosByIdHandler : IRequestHandler<GetPedidosRecebidosByIdQuery, PedidosMatchResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPedidosRecebidosByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<PedidosMatchResponse> Handle(GetPedidosRecebidosByIdQuery request, CancellationToken cancellationToken)
        {
            PedidosMatchResponse pedidosMatchResponse = new PedidosMatchResponse
            {
                IdUser = request.UserId
            };
            List<PedidoResponse> pedidosResponse = new List<PedidoResponse>();

            var pedidos = _dbContext.PedidosMatch
                            .Include(p => p.IdStatusSolicitacao)
                            .Where(p => p.IdUserAprovador == request.UserId)
                            .ToArray();

            foreach (var p in pedidos)
            { 
                if(p.IdStatusSolicitacao.Id == 1)
                {
                    PedidoResponse pedido = new PedidoResponse();
                    pedido.IdUser = p.IdUserSolicitante;
                    pedido.DataSolicitacao = p.DataSolicitacao;
                    pedidosResponse.Add(pedido);
                }
            }

            pedidosMatchResponse.Pedidos = pedidosResponse;

            return pedidosMatchResponse;
        }

    }
}
