using MetWorkingMatch.Application.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions.PedidoMatch
{
    [Binding]
    public class AceitarPedidoDeMatchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _urlAceitarPedidoMatch;

        public AceitarPedidoDeMatchSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._urlAceitarPedidoMatch = "https://localhost:5003/api/v1/PedidoMatch/aceitar/?";
        }

        [When(@"o usuário (.*) aceitar o pedido de outro usuário")]
        public void QuandoOUsuarioRejeitarOPedidoDeOutroUsuario(Guid IdUser)
        {
            var reponseRecebidos = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];
            Guid IdAmigo = new Guid();

            if (reponseRecebidos.IsOk)
            {
                IdAmigo = reponseRecebidos.Data.Pedidos[0].IdUser;
            }

            var request = new RestRequest(Method.PUT);

            var restClient = new RestClient(_urlAceitarPedidoMatch + "IdUserSolicitante="+IdAmigo+ "&IdUserAprovador="+IdUser);
            var response = restClient.Execute(request);
        }
    }
}
