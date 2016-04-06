using System.Web.Http;
using System.Web.Http.Results;

namespace Xamless.Api
{
    [Route("api/tickets")]
    public class FileController: ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(new { id = 1});
        }
    }
}
