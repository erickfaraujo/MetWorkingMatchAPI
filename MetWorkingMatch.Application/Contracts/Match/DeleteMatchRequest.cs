using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetWorkingMatch.Application.Contracts.Match
{
    public class DeleteMatchRequest
    {
        public Guid IdUser { get; set; }
        public Guid IdUserAmigo { get; set; }

    }
}
