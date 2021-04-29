using System;
using System.Net.Http;
using System.Threading.Tasks;
using MetWorkingMatch.Domain.Models;
using System.Text.Json;
using MetWorkingMatch.Domain.Interfaces;

namespace MetWorkingMatch.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetUser(Guid userId)
        {
            var httpResponseMessage = await _httpClient.GetAsync(
                $"User/{userId}");

            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseFriendComparison = JsonSerializer.Deserialize<UserResponse>(readAsStringAsync);

            if (responseFriendComparison != null && responseFriendComparison.isOk)
            {
                return responseFriendComparison.data;   
            }
            return null;
        } 
    }
}