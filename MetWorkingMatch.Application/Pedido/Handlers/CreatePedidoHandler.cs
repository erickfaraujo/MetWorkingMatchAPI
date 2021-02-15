using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Pedido.Handlers
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, PedidoResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePedidoHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PedidoResponse> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = _mapper.Map<PedidoMatch>(request.PedidoRequest);
            pedido.DataSolicitacao = System.DateTime.Now;
            pedido.IdStatusSolicitacao = await _dbContext.StatusPedido.FindAsync(1);

            await _dbContext.PedidosMatch.AddAsync(pedido, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PedidoResponse>(pedido);
        }
    }
}
