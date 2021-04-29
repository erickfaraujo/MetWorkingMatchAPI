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
    public class GetPedidosEnviadosByIdHandler : IRequestHandler<GetPedidosEnviadosByIdQuery, BaseResponse<PedidosMatchResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetPedidosEnviadosByIdHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _dbContext = context;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<BaseResponse<PedidosMatchResponse>> Handle(GetPedidosEnviadosByIdQuery request, CancellationToken cancellationToken)
        {
            var pedidos = _dbContext.PedidosMatch
                            .Include(p => p.IdStatusSolicitacao)
                            .Where(p => p.IdUserSolicitante == request.UserId && p.IdStatusSolicitacao.Id == 1);

            var pedidosEnviados = pedidos.ToList();
            
            var response = new BaseResponse<PedidosMatchResponse>();

            if (!pedidosEnviados.Any())
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
                
                foreach (var p in pedidosEnviados)
                {
                    var user = await _userService.GetUser(p.IdUserAprovador);
                    var pedido = new PedidoResponse {IdUser = p.IdUserAprovador, DataSolicitacao = p.DataSolicitacao, User = user};
                    pedidosResponse.Add(pedido);
                }
                pedidosMatchResponse.Pedidos = pedidosResponse;
                response.SetIsOk(pedidosMatchResponse);
            }

            return response;
        }
    }
}
