using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Login;
using Tempsense.Entities.Dtos.Dtos.Login;

namespace Tempsense.web.Controllers.Login
{
    public class LoginController : ApiController
    {
        private readonly ILoginInterfazBussines _ILoginInterfazBussines;
        public LoginController()
        {

        }

        public LoginController(ILoginInterfazBussines ILoginInterfazBussines)
        {
            _ILoginInterfazBussines = ILoginInterfazBussines;
        }

        [HttpPost]
        [Route("CrearSessionUsuario")]
        public HttpResponseMessage CrearSessionUsuario(ObjetoSesion objetoSesion)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ILoginInterfazBussines.CrearSessionUsuario(objetoSesion));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("CerrarSesionUsuario")]
        public HttpResponseMessage CerrarSesionUsuario(LoginDto objLogin)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ILoginInterfazBussines.CerrarSesionUsuario(objLogin));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


    }
}