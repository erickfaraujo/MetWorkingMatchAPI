using System;
using System.Threading.Tasks;

namespace MetWorkingMatch.Domain.Interfaces
{
    public interface IGeoService
    {
        Task DeleteFromTimeLine(Guid idUserAprovador, Guid idUserSolicitante);
    }
}