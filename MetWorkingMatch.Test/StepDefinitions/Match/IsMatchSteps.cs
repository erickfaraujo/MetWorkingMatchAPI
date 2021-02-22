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
    public class IsMatchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlIsMatch;
        public IsMatchSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlIsMatch = "https://localhost:5003/api/v1/Match/isMatch/";
        }


        [When(@"for efetuado uma requisição enviando o (.*) e (.*)")]
        public void QuandoOForEfetuadoUmaRequisicaoEnviandoOE(Guid IdUser, Guid IdUserAmigo)
        {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Parameters.Clear();

            var restClient = new RestClient(_urlIsMatch + IdUser + "/" + IdUserAmigo);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<IsMatchResponse>>(content);

            _scenarioContext["isMatchResponse"] = jsonResponse;
        }

        [Then(@"o sistema verifica se os dois formam um match enviando o resultado (.*)")]
        public void EntaoOSistemaVerificaSeOsDoisFormamUmMatchEnviandoOResultado(bool isMatch)
        {
            BaseResponse<IsMatchResponse> isMatchResponse = (BaseResponse<IsMatchResponse>)_scenarioContext["isMatchResponse"];

            Assert.AreEqual(isMatch, isMatchResponse.Data.IsMatch);
        }
    }
}
