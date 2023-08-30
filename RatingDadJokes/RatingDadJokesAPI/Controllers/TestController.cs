using Microsoft.AspNetCore.Mvc;
using RatingDadJokes.Data.Service.Commands;
using RatingDadJokes.Shared.Secrets;

namespace RatingDadJokesAPI.Controllers
{
    [ApiController]
    [Route("Test")]
    public class TestController : ControllerBase
    {
        private readonly IAddJokeCommand _addJokeCommand;
        private readonly ISecretManager _secretManager;

        public TestController(IAddJokeCommand addJojeCommand,
            ISecretManager secretManager)
        {
            _addJokeCommand = addJojeCommand;
            _secretManager = secretManager;
        }

        [HttpGet]
        public async Task<string> TestMethod()
        {
            var secret = await _secretManager.Get<SecretsRegistry.JokesApiKey>(SecretsRegistry.ExternalJokesDataApiKey);
            var aa = secret.dadjokeapikey.ToString();
            return "SERVICE RUNNING";
        }
    }
}
