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
    public class IsMatchHandler : IRequestHandler<IsMatchQuery, BaseResponse<IsMatchResponse>>
    {

        private readonly IApplicationDbContext _dbContext;

        public IsMatchHandler(IApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BaseResponse<IsMatchResponse>> Handle(IsMatchQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IsMatchResponse>();
            bool IsMatch = false;
            IsMatchResponse isMatchResponse = new IsMatchResponse();

            var matchesQuery = _dbContext.Matches.Where(m => m.IdUser == request.UserId);

            if (matchesQuery.Any())
            {
                var matches = matchesQuery.ToList();
                foreach (var m in matches)
                {
                    if (m.IdAmigo == request.IdAmigo)
                    {
                        IsMatch = true;
                    }
                }
            }
            isMatchResponse.IsMatch = IsMatch;
            response.SetIsOk(isMatchResponse);

            return response;
        }
    }
}
