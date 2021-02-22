using MetWorkingMatch.Application.Contracts;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace MetWorkingMatch.Test.StepDefinitions.PedidoMatch
{
    [Binding]
    public class CancelarPedidoDeMatchSteps
    {
        public class EnviarPedidoDeMatchSteps
        {
            private readonly ScenarioContext _scenarioContext;
            private readonly string _urlPedidoMatch;
            private readonly string _urlGetEnviados;

            public EnviarPedidoDeMatchSteps(ScenarioContext scenarioContext)
            {
                this._scenarioContext = scenarioContext;
                this._urlPedidoMatch = "https://localhost:5003/api/v1/PedidoMatch/";
                this._urlGetEnviados = "https://localhost:5003/api/v1/PedidoMatch/enviados/";
            }
            [Given(@"que o usuário (.*) possua (.*) um pedido de match enviado")]
            public void DadoQueOUsuarioPossuaUmPedidoDeMatchEnviado(Guid IdUser, bool possui)
            {
                var request = new RestRequest();
                request.Method = Method.GET;

                request.Parameters.Clear();

                var restClient = new RestClient(_urlGetEnviados + IdUser);

                var response = restClient.Execute(request);

                var content = response.Content.ToString();

                dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);

                _scenarioContext["response"] = jsonResponse;

                BaseResponse<PedidosMatchResponse> finalResponse = (BaseResponse<PedidosMatchResponse>)_scenarioContext["response"];

                Assert.AreEqual(possui, finalResponse.IsOk);
            }

            [When(@"o usuário (.*) cancelar o pedido de outro usuário (.*)")]
            public void QuandoOUsuarioCancelarOPedidoDeOutroUsuario(Guid IdUser, Guid IdAmigo)
            {
                var request = new RestRequest(Method.DELETE);
                request.RequestFormat = DataFormat.Json;

                var restClient = new RestClient(_urlPedidoMatch + "IdUserSolicitante=" + IdAmigo + "&IdUserAprovador=" + IdUser);
                var response = restClient.Execute(request);

                var content = response.ToString();

                dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);

                _scenarioContext["response"] = jsonResponse;
            }


            [When(@"o usuário (.*) quiser cancelar o pedido que não existe (.*)")]
            public void QuandoOUsuarioQuiserCancelarOPedidoQueNaoExiste(Guid IdUser, Guid IdAmigo)
            {
                var request = new RestRequest(Method.DELETE);
                request.RequestFormat = DataFormat.Json;

                var restClient = new RestClient(_urlPedidoMatch + "IdUserSolicitante=" + IdAmigo + "&IdUserAprovador=" + IdUser);
                var response = restClient.Execute(request);

                var content = response.ToString();

                dynamic jsonResponse = JsonConvert.DeserializeObject<BaseResponse<PedidosMatchResponse>>(content);

                _scenarioContext["response"] = jsonResponse;
            }

            [Given(@"que o usuário (.*) possua (.*) um pedido de match enviado")]
            public void DadoQueOUsuarioPossuaUmPedidoDeMatchEnviado(string p0, string p1)
            {
                ScenarioContext.Current.Pending();
            }

            [When(@"o usuário (.*) cancelar o pedido de outro usuário (.*)")]
            public void QuandoOUsuarioCancelarOPedidoDeOutroUsuario(string p0, string p1)
            {
                ScenarioContext.Current.Pending();
            }

            [When(@"o usuário (.*) quiser cancelar o pedido que não existe (.*)")]
            public void QuandoOUsuarioQuiserCancelarOPedidoQueNaoExiste(string p0, string p1)
            {
                ScenarioContext.Current.Pending();
            }


        }
    }
}


