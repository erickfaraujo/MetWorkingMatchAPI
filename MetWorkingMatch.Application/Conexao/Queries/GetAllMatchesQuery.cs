using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using System;

namespace MetWorkingMatch.Application.Conexao.Queries
{
    public class DeleteMatchRequest : IRequest<BaseResponse<MatchesAtivosResponse>>
    {
        public Guid UserId;

        public DeleteMatchRequest(Guid UserId)
        {
            this.UserId = UserId;
        }
    }
}
