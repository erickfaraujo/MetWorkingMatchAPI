using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Queries;
using MetWorkingMatch.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class GetPedidosEnviadosByIdHandler : IRequestHandler<GetPedidosEnviadosByIdQuery, PedidosMatchResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPedidosEnviadosByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<PedidosMatchResponse> Handle(GetPedidosEnviadosByIdQuery request, CancellationToken cancellationToken)
        {
            PedidosMatchResponse pedidosMatchResponse = new PedidosMatchResponse();
            pedidosMatchResponse.IdUserSolicitante = request.UserId;
            List<PedidoResponse> pedidosResponse = new List<PedidoResponse>();

            var pedidos = _dbContext.PedidosMatch.Where(p => p.IdUserSolicitante == request.UserId).ToArray();

            foreach (var p in pedidos)
            {
                PedidoResponse pedido = new PedidoResponse();
                pedido.IdUserAprovador = p.IdUserAprovador;
                pedido.DataSolicitacao = p.DataSolicitacao;

                pedidosResponse.Add(pedido);
            }

            pedidosMatchResponse.Pedidos = pedidosResponse;

            return pedidosMatchResponse;
        }
    }
}
