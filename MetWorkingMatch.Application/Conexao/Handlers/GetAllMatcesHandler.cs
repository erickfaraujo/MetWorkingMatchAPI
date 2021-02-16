using MediatR;
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
    public class GetAllMatcesHandler : IRequestHandler<Queries.DeleteMatchRequest, BaseResponse<MatchesAtivosResponse>>
    {

        private readonly IApplicationDbContext _dbContext;

        public GetAllMatcesHandler(IApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BaseResponse<MatchesAtivosResponse>> Handle(Queries.DeleteMatchRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<MatchesAtivosResponse>();
            MatchesAtivosResponse matchesAtivosResponse = new MatchesAtivosResponse
            {
                IdUser = request.UserId
            };

            List<MatchResponse> matchesList = new List<MatchResponse>();

            var matchesQuery = _dbContext.Matches.Where(m => m.IdUser == request.UserId);

            if (!matchesQuery.Any())
            {
                response.SetValidationErrors(new[] { "Usuário não possui matches ativos" });
            }
            else
            {
                var matches = matchesQuery.ToList();
                foreach (var m in matches)
                {
                    MatchResponse matchResponse = new MatchResponse();
                    matchResponse.IdAmigo = m.IdAmigo;
                    matchResponse.DataConexão = m.dataConexao;
                    matchesList.Add(matchResponse);
                }

                matchesAtivosResponse.Matches = matchesList;

                response.SetIsOk(matchesAtivosResponse);
            }

            return response;
        }
    }
}
