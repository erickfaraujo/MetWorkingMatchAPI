using System;
using System.Net.Http;
using System.Threading.Tasks;
using MetWorkingMatch.Domain.Interfaces;

namespace MetWorkingMatch.Infra.Services
{
    public class GeoService : IGeoService
    {
        private readonly HttpClient _httpClient;

        public GeoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteFromTimeLine(Guid idUserAprovador, Guid idUserSolicitante)
        {
            var result = await _httpClient.DeleteAsync($"{idUserAprovador}/{idUserSolicitante}");
        }
    }
}