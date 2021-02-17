using MetWorkingMatch.Application.Contracts;
using MetWorkingMatch.Application.Contracts.Match;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions.Match
{
    [Binding]
    public class ListarMatchesEfetivadosSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlGetMatches;

        public ListarMatchesEfetivadosSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlGetMatches = "https://localhost:5001/api/v1/Match/";
        }

        [When(@"o usuário (.*) quiser ver a lista de matches efetivados")]
        public void QuandoOUsuarioQuiserVerAListaDeMatchesEfetivados(string IdUser)
        {
            var request = new RestRequest();
            request.Method = Method.GET;

            request.Parameters.Clear();

            var restClient = new RestClient(_urlGetMatches + IdUser);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<MatchesAtivosResponse>>(content);

            _scenarioContext["response"] = jsonResponse;
        }

        [Then(@"o retorno de matches deve ser (.*)")]
        public void EntaoORetornoDeMatchesDeveSer(bool isOk)
        {
            BaseResponse<MatchesAtivosResponse> finalResponse;
            finalResponse = (BaseResponse<MatchesAtivosResponse>)_scenarioContext["response"];

            Assert.AreEqual(isOk, finalResponse.IsOk);
        }

        [Then(@"a lista de matches deverá ser exibida (.*)")]
        public void EntaoAListaDeMatchesDeveraSerExibida(Guid IdUserAmigo)
        {
            BaseResponse<MatchesAtivosResponse> finalResponse;

            finalResponse = (BaseResponse<MatchesAtivosResponse>)_scenarioContext["response"];

            Assert.AreEqual(IdUserAmigo, finalResponse.Data.Matches[0].IdAmigo);
        }
    }
}
