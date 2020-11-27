using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Maestros;

namespace Tempsense.web.Controllers.Maestros
{
    public class MaestrosController : ApiController
    {
        private readonly IMaestrosInterfazBussines _IMaestrosInterfazBussines;
        public MaestrosController()
        {

        }

        public MaestrosController(IMaestrosInterfazBussines IMaestrosInterfazBussines)
        {
            _IMaestrosInterfazBussines = IMaestrosInterfazBussines;
        }

        [HttpGet]
        [Route("GetAllMedidas")]
        public HttpResponseMessage GetAllMedidas()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IMaestrosInterfazBussines.ListarMedidas());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
