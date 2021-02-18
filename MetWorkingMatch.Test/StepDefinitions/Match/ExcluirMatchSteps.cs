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
    public class ExcluirMatchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlMatches;
        private readonly string _urlIsMatch;

        public ExcluirMatchSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlMatches = "https://localhost:5001/api/v1/Match";
            this._urlIsMatch = "https://localhost:5001/api/v1/Match/isMatch/";
        }
        [Given(@"que o usuário (.*) possua uma conexão com outro usuário (.*)")]

        public void DadoQueOUsuarioPossuaUmaConexaoComOutroUsuario(Guid IdUser, Guid IdUserAmigo)
        {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Parameters.Clear();

            var restClient = new RestClient(_urlIsMatch + IdUser + "/" + IdUserAmigo);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<IsMatchResponse>>(content);

            BaseResponse<IsMatchResponse> IsMatchResponse = jsonResponse;

            Assert.AreEqual(IsMatchResponse.Data.IsMatch, true);
        }

        [Given(@"que o usuário (.*) não possua uma conexão com o outro usuário informado (.*)")]
        public void DadoQueOUsuarioNaoPossuaUmaConexaoComOOutroUsuarioInformado(Guid IdUser, Guid IdUserAmigo)
        {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Parameters.Clear();

            var restClient = new RestClient(_urlIsMatch + IdUser + "/" + IdUserAmigo);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<IsMatchResponse>>(content);

            BaseResponse<IsMatchResponse> IsMatchResponse = jsonResponse;

            Assert.AreEqual(IsMatchResponse.Data.IsMatch, false);
        }

        [When(@"o usuário (.*) quiser excluir a conexão (.*)")]
        public void QuandoOUsuarioQuiserExcluirAConexao(Guid IdUser, Guid IdUserAmigo)
        {
            var request = new RestRequest();
            request.Method = Method.DELETE;
            request.Parameters.Clear();

            var restClient = new RestClient(_urlMatches + "?IdUser=" + IdUser + "&IdUserAmigo=" + IdUserAmigo);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<MatchesAtivosResponse>>(content);

            _scenarioContext["jsonResponse"] = jsonResponse;
        }

        [Then(@"o retorno da exclusão deve ser (.*)")]
        public void EntaoORetornoDaExclusaoDeveSer(bool isOK)
        {
            BaseResponse<MatchesAtivosResponse> finalResponse;

            var response = (BaseResponse<MatchesAtivosResponse>)_scenarioContext["jsonResponse"];

            Assert.AreEqual(isOK, response.IsOk);
        }
    }
}
