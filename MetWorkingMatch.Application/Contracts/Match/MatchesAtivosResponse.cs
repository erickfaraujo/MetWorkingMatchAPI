using System;
using System.Collections.Generic;

namespace MetWorkingMatch.Application.Contracts.Match
{
    public class MatchesAtivosResponse
    {
        public Guid IdUser { get; set; }
        public List<MatchResponse> Matches { get; set; }

    }
}
