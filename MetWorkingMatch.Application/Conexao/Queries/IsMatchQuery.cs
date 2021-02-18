using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using System;

namespace MetWorkingMatch.Application.Conexao.Queries
{
    public class IsMatchQuery : IRequest<BaseResponse<IsMatchResponse>>
    {
        public Guid UserId;
        public Guid IdAmigo;

        public IsMatchQuery(Guid UserId, Guid IdAmigo)
        {
            this.UserId = UserId;
            this.IdAmigo = IdAmigo;
        }
    }
}
