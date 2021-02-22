using MetWorkingMatch.Application.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions.PedidoMatch
{
    [Binding]
    public class RejeitarPedidoDeMatchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlRejeitarPedidoMatch;
        private readonly string _urlGetRecebidos;

        public RejeitarPedidoDeMatchSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlRejeitarPedidoMatch = "https://localhost:5003/api/v1/PedidoMatch/rejeitar/?";
            this._urlGetRecebidos = "https://localhost:5003/api/v1/PedidoMatch/recebidos/";
        }
        [Given(@"que o usuário (.*) possua (.*) um pedido de match recebido")]
        public void DadoQueOUsuarioPossuaUmPedidoDeMatchRecebido(Guid IdUser, bool possui)
        {
            var request = new RestRequest();
            request.Method = Method.GET;

            request.Parameters.Clear();

            var restClient = new RestClient(_urlGetRecebidos + IdUser);

            var response = restClient.Execute(request);

            var content = response.Content.ToString();

            dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);
            _scenarioContext["response"] = jsonResponse;

            BaseResponse<PedidosMatchResponse> responseBase = (BaseResponse<PedidosMatchResponse>)jsonResponse;

            Assert.AreEqual(possui, responseBase.IsOk);
        }

        [When(@"o usuário (.*) rejeitar o pedido de outro usuário")]
        public void QuandoOUsuarioRejeitarOPedidoDeOutroUsuario(Guid IdUser)
        {
            var reponseRecebidos = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];
            Guid IdAmigo = reponseRecebidos.Data.Pedidos[0].IdUser;

            var request = new RestRequest(Method.PUT);

            var restClient = new RestClient(_urlRejeitarPedidoMatch+ "IdUserSolicitante="+IdAmigo+ "&IdUserAprovador="+IdUser);
            var response = restClient.Execute(request);
        }

        [When(@"o usuário (.*) quiser rejeitar o pedido que não existe")]
        public void QuandoOUsuarioQuiserRejeitarOPedidoQueNaoExiste(Guid IdUser)
        {
            var reponseRecebidos = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];
            Guid IdAmigo = new Guid();

            var request = new RestRequest(Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new
            {
                idUserSolicitante = IdAmigo,
                idUserAprovador = IdUser
            });

            var restClient = new RestClient(_urlRejeitarPedidoMatch + "IdUserSolicitante=" + IdAmigo + "&IdUserAprovador=" + IdUser);
            var response = restClient.Execute(request);
        }

    }
}
