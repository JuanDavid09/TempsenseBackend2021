using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Perfiles;

namespace Tempsense.web.Controllers.Perfiles
{
    public class PerfilesController : ApiController
    {
        private readonly IPerfilesInterfazBussines _IPerfilesInterfazBussines;
        public PerfilesController()
        {

        }
        public PerfilesController(IPerfilesInterfazBussines IPerfilesInterfazBussines)
        {
            _IPerfilesInterfazBussines  = IPerfilesInterfazBussines;
        }


        [HttpGet]
        [Route("GetAllProfiles")]
        public HttpResponseMessage GetAllProfiles()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IPerfilesInterfazBussines.GetAllProfiles());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}