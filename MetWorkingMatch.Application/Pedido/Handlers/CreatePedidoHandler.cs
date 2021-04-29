using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Domain.Entities;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MetWorkingMatch.Domain.Interfaces;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, BaseResponse<PedidoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGeoService _geoService;

        public CreatePedidoHandler(IApplicationDbContext dbContext, IMapper mapper, IGeoService geoService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _geoService = geoService;
        }
        public async Task<BaseResponse<PedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PedidoResponse>();

            var pedido = _mapper.Map<PedidoMatch>(request.PedidoRequest);
            pedido.DataSolicitacao = System.DateTime.Now;
            pedido.IdStatusSolicitacao = await _dbContext.StatusPedido.FindAsync(1);

            var pedidoPendente = _dbContext.PedidosMatch
                                    .Where(p => p.IdUserAprovador == request.PedidoRequest.IdUserAprovador)
                                    .Where(p => p.IdUserSolicitante == request.PedidoRequest.IdUserSolicitante)
                                    .Where(p => p.IdStatusSolicitacao.Id == 1);

            if (pedidoPendente.Any())
            {
                response.SetValidationErrors(new[] { "Já existe uma conexão ou pedido de match pendente para esse usuários" });
            }

            else
            {
                await _dbContext.PedidosMatch.AddAsync(pedido, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            _geoService.DeleteFromTimeLine(request.PedidoRequest.IdUserAprovador,
                request.PedidoRequest.IdUserSolicitante);
            response.SetIsOk(null);
            return response;
        }
    }
}
