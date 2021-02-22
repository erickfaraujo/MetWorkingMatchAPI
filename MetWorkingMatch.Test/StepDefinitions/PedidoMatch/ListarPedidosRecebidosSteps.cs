using MetWorkingMatch.Application.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions.PedidoMatch
{
    [Binding]
    public class ListarPedidosRecebidosSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlGetRecebidos;

        public ListarPedidosRecebidosSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlGetRecebidos = "https://localhost:5003/api/v1/PedidoMatch/recebidos/";
        }

        [When(@"o usuário (.*) quiser ver a lista de pedidos recebidos")]
        public void QuandoOUsuarioQuiserVerAListaDePedidosEnviadosPendentes(Guid IdUser)
        {
            var request = new RestRequest();
            request.Method = Method.GET;

            request.Parameters.Clear();

            var restClient = new RestClient(_urlGetRecebidos + IdUser);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);

            _scenarioContext["response"] = jsonResponse;

        }

        [Then(@"a lista de pedidos recebidos deverá ser exibida (.*)")]
        public void EntaoAListaDePedidosRecebidosDeveraSerExibida(Guid IdUser)
        {
            BaseResponse<PedidosMatchResponse> finalResponse;

            finalResponse = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];

            Assert.AreEqual(IdUser, finalResponse.Data.Pedidos[0].IdUser);
        }
    }

}
