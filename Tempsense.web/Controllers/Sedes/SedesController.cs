using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Sedes;
using Tempsense.Entities.Dtos.Dtos.Sedes;

namespace Tempsense.web.Controllers.Sedes
{
    public class SedesController : ApiController
    {
        private readonly ISedesInterfazBussines _ISedesInterfazBussines;
        public SedesController()
        {

        }

        public SedesController(ISedesInterfazBussines ISedesInterfazBussines)
        {
            _ISedesInterfazBussines = ISedesInterfazBussines;
        }


        [HttpGet]
        [Route("GetAllSedes")]
        public HttpResponseMessage GetAllSedes()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ISedesInterfazBussines.ListarSedesAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearSede")]
        public HttpResponseMessage CrearSede(SedesDto sedesDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ISedesInterfazBussines.CrearSede(sedesDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("EditarSedeId")]
        public HttpResponseMessage EditarSedeId(SedesDto sedesDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ISedesInterfazBussines.EditarSedeId(sedesDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("EliminarSede")]
        public HttpResponseMessage EliminarSede(int sede)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ISedesInterfazBussines.EliminarSede(sede));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarSedeId")]
        public HttpResponseMessage ListarSedeId(int sede)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ISedesInterfazBussines.ListarSedeId(sede));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
