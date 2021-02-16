using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, BaseResponse<PedidoResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePedidoHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<PedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PedidoResponse>();

            var pedido = _mapper.Map<PedidoMatch>(request.PedidoRequest);
            pedido.DataSolicitacao = System.DateTime.Now;
            pedido.IdStatusSolicitacao = await _dbContext.StatusPedido.FindAsync(1);

            var PedidoPendente = _dbContext.PedidosMatch
                                    .Where(p => p.IdUserAprovador == request.PedidoRequest.IdUserAprovador)
                                    .Where(p => p.IdUserSolicitante == request.PedidoRequest.IdUserSolicitante);

            if (PedidoPendente.Any())
            {
                response.SetValidationErrors(new[] { "Já existe uma conexão ou pedido de match pendente para esse usuários" });
            }

            await _dbContext.PedidosMatch.AddAsync(pedido, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.SetIsOk(null);
            return response;
        }
    }
}
