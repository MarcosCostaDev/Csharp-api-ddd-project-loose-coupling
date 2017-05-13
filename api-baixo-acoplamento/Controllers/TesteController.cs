using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace api_baixo_acoplamento.Controllers
{

    [RoutePrefix("api/teste")]
    public class TesteController : ApiController
    {
        [HttpGet, Route("status")]
        public Task<HttpResponseMessage> Status()
        {
            var response = new HttpResponseMessage();

            var resultado = new { Nome = "Marcos", Idade= 25};

            response = Request.CreateResponse(HttpStatusCode.OK, resultado);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }
    }
}