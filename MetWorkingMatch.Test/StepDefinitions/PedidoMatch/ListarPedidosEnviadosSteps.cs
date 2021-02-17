using MetWorkingMatch.Application.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions
{
    [Binding]
    public class ListarPedidosEnviadosSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlGetEnviados;

        public ListarPedidosEnviadosSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlGetEnviados = "https://localhost:5001/api/v1/PedidoMatch/enviados/";
        }

        [When(@"o usuário (.*) quiser ver a lista de pedidos enviados pendentes")]
        public void QuandoOUsuarioQuiserVerAListaDePedidosEnviadosPendentes(Guid IdUser)
        {
            var request = new RestRequest();
            request.Method = Method.GET;

            request.Parameters.Clear();

            var restClient = new RestClient(_urlGetEnviados + IdUser);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);

            _scenarioContext["response"] = jsonResponse;

        }

        [Then(@"o retorno deve ser (.*)")]
        public void EntaoORetornoDeveSer(bool isOk)
        {
            BaseResponse<PedidosMatchResponse> finalResponse;
            finalResponse = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];

            Assert.AreEqual(isOk, finalResponse.IsOk);
        }

        [Then(@"a lista de pedidos enviados deverá ser exibida (.*)")]
        public void EntaoAListaDePedidosPendentesDeveraSerExibida(Guid IdUserAmigo)
        {

            BaseResponse<PedidosMatchResponse> finalResponse;

            finalResponse = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];

            Assert.AreEqual(IdUserAmigo, finalResponse.Data.Pedidos[0].IdUser);
        }
    }
}
