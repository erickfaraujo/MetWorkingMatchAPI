using AutoMapper;
using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Interfaces;
using MetWorkingMatch.Application.Pedido.Queries;
using MetWorkingMatch.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

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
            var pedido = await _dbContext.PedidosMatch.FindAsync(request.UserId);

            return _mapper.Map<PedidosMatchResponse>(pedido);
        }
    }
}
