using MediatR;
using MetWorkingMatch.Application.Conexao.Queries;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using MetWorkingMatch.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Conexao.Handlers
{
    public class ShowTimelineHandler : IRequestHandler<ShowTimelineQuery, BaseResponse<ShowTimelineResponse>>
    {

        private readonly IApplicationDbContext _dbContext;

        public ShowTimelineHandler(IApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BaseResponse<ShowTimelineResponse>> Handle(ShowTimelineQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ShowTimelineResponse>();
            bool isMatch = false;
            bool isPendingRequest = false;
            ShowTimelineResponse showTimelineResponse = new ShowTimelineResponse { Show = false };

            // Busca se os usuários são amigos
            var matchesQuery = _dbContext.Matches.Where(m => m.IdUser == request.UserId);

            if (matchesQuery.Any())
            {
                var matches = matchesQuery.ToList();
                foreach (var m in matches)
                {
                    if (m.IdAmigo == request.IdAmigo)
                    {
                        isMatch = true;
                    }
                }
            }

            // Busca se existe um pedido pendente entre os usuários
            var PedidoPendenteUser = _dbContext.PedidosMatch
                                    .Where(p => p.IdUserAprovador == request.IdAmigo)
                                    .Where(p => p.IdUserSolicitante == request.UserId)
                                    .Where(p => p.IdStatusSolicitacao.Id == 1);

            var PedidoPendenteAmigo = _dbContext.PedidosMatch
                                    .Where(p => p.IdUserAprovador == request.UserId)
                                    .Where(p => p.IdUserSolicitante == request.IdAmigo)
                                    .Where(p => p.IdStatusSolicitacao.Id == 1);

            if (PedidoPendenteUser.Any() || PedidoPendenteAmigo.Any()) isPendingRequest = true;

            // Se não houver match nem pedido pendente então é exibido na timeline
            if (isMatch == false && isPendingRequest == false) showTimelineResponse.Show = true;

            response.SetIsOk(showTimelineResponse);

            return response;
        }
    }
}
