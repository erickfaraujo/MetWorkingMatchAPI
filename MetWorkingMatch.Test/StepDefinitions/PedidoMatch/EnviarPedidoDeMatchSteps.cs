using MetWorkingMatch.Application.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions.PedidoMatch
{
    [Binding]
    public class EnviarPedidoDeMatchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlPedidoMatch;

        public EnviarPedidoDeMatchSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlPedidoMatch = "https://localhost:5003/api/v1/PedidoMatch/";
        }

        [When(@"o usuário (.*) enviar um pedido de match ao (.*)")]
        public void QuandoOUsuarioEnviarUmPedidoDeMatchAo(string idUser, string idAmigo)
        {
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                idUserSolicitante = idUser,
                idUserAprovador = idAmigo
            });

            var restClient = new RestClient(_urlPedidoMatch);
            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);

            _scenarioContext["response"] = jsonResponse;
        }

        [Then(@"o sistema deve retornar o status (.*)")]
        public void EntaoOSistemaDeveRetornarOStatus(bool isOk)
        {
            BaseResponse<PedidosMatchResponse> response = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];

            Assert.AreEqual(isOk, response.IsOk);
        }
    }
}
