using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Commands;
using MetWorkingMatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //StatusPedido status = new StatusPedido(1);
            //pedido.IdStatusSolicitacao = status;

            await _dbContext.PedidosMatch.AddAsync(pedido, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new PedidoResponse();
        }
    }
}
