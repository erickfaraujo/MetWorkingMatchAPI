using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Queries;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using MetWorkingMatch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class GetPedidosRecebidosByIdHandler : IRequestHandler<GetPedidosRecebidosByIdQuery, BaseResponse<PedidosMatchResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetPedidosRecebidosByIdHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _dbContext = context;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<BaseResponse<PedidosMatchResponse>> Handle(GetPedidosRecebidosByIdQuery request, CancellationToken cancellationToken)
        {
            var pedidos = _dbContext.PedidosMatch
                            .Include(p => p.IdStatusSolicitacao)
                            .Where(p => p.IdUserAprovador == request.UserId && p.IdStatusSolicitacao.Id == 1);

            var pedidosRecebidos = pedidos.ToList();
            
            var response = new BaseResponse<PedidosMatchResponse>();

            if (!pedidosRecebidos.Any())
            {
                response.SetValidationErrors(new[] { "Não existem pedidos pendentes para o usuário informado" });
            }
            else
            {
                var pedidosMatchResponse = new PedidosMatchResponse
                {
                    IdUser = request.UserId
                };

                var pedidosResponse = new List<PedidoResponse>();
                foreach (var p in pedidosRecebidos)
                {
                    var user = await _userService.GetUser(p.IdUserSolicitante);
                    var pedido = new PedidoResponse {IdUser = p.IdUserSolicitante, DataSolicitacao = p.DataSolicitacao, User = user};
                    pedidosResponse.Add(pedido);
                }
                pedidosMatchResponse.Pedidos = pedidosResponse;
                response.SetIsOk(pedidosMatchResponse);
            }

            return response;
        }

    }
}
