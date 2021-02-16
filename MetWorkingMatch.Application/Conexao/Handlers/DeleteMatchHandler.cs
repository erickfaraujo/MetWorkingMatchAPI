using MediatR;
using MetWorkingMatch.Application.Conexao.Commands;
using MetWorkingMatch.Application.Conexao.Queries;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using MetWorkingMatch.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Conexao.Handlers
{
    public class DeleteMatchHandler : IRequestHandler<DeleteMatchCommand, BaseResponse<MatchResponse>>
    {

        private readonly IApplicationDbContext _dbContext;

        public DeleteMatchHandler(IApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BaseResponse<MatchResponse>> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<MatchResponse>();
            var match = _dbContext.Matches
                                .Where(m => m.IdUser == request.DeleteMatchRequest.IdUser)
                                .Where(m => m.IdAmigo == request.DeleteMatchRequest.IdUserAmigo);

            var matchAmigo = _dbContext.Matches
                                .Where(m => m.IdAmigo == request.DeleteMatchRequest.IdUser)
                                .Where(m => m.IdUser == request.DeleteMatchRequest.IdUserAmigo);

            if (!match.Any() || !matchAmigo.Any())
            {
                response.SetValidationErrors(new[] { "Pedido de Match não encontrado" });
            }
            else
            {
                var matchLista = match.ToList();
                var matchAmigoLista = matchAmigo.ToList();

                _dbContext.Matches.Remove(matchLista[0]);
                _dbContext.Matches.Remove(matchAmigoLista[0]);

                var pedidoMatch = _dbContext.PedidosMatch
                                        .Where(p => p.IdUserSolicitante == request.DeleteMatchRequest.IdUser)
                                        .Where(p => p.IdUserAprovador == request.DeleteMatchRequest.IdUserAmigo);

                if (!pedidoMatch.Any())
                {
                    pedidoMatch = _dbContext.PedidosMatch
                                        .Where(p => p.IdUserAprovador == request.DeleteMatchRequest.IdUser)
                                        .Where(p => p.IdUserSolicitante == request.DeleteMatchRequest.IdUserAmigo);
                }

                _dbContext.PedidosMatch.Remove(pedidoMatch.ToList()[0]);

                await _dbContext.SaveChangesAsync(cancellationToken);

                response.SetIsOk(null);
            }

            return response;
        }
    }
}
