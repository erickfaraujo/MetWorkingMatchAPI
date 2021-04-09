using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using System;

namespace MetWorkingMatch.Application.Conexao.Queries
{
    public class ShowTimelineQuery : IRequest<BaseResponse<ShowTimelineResponse>>
    {
        public Guid UserId;
        public Guid IdAmigo;

        public ShowTimelineQuery(Guid UserId, Guid IdAmigo)
        {
            this.UserId = UserId;
            this.IdAmigo = IdAmigo;
        }
    }
}
