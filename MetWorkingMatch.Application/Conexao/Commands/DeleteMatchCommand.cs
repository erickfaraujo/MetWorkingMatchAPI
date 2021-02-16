using MediatR;
using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;

namespace MetWorkingMatch.Application.Conexao.Commands
{
    public class DeleteMatchCommand : IRequest<BaseResponse<MatchResponse>>
    {

        public DeleteMatchRequest DeleteMatchRequest;

        public DeleteMatchCommand(DeleteMatchRequest deleteMatchRequest)
        {
            this.DeleteMatchRequest = deleteMatchRequest;
        }
    }
}
