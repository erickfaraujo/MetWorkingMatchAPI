using System;
using System.Threading.Tasks;
using MetWorkingMatch.Domain.Models;

namespace MetWorkingMatch.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId);
    }
}