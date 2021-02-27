using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Dispositivos;
using Tempsense.Entities.Dtos.Dtos.Dispositivos;

namespace Tempsense.web.Controllers.Dispositivos
{
    public class DispositivosController : ApiController
    {
        private readonly IDispositivosInterfazBussines _IDispositivosInterfazBussines;
        public DispositivosController()
        {

        }

        public DispositivosController(IDispositivosInterfazBussines IDispositivosInterfazBussines)
        {
            _IDispositivosInterfazBussines = IDispositivosInterfazBussines;
        }

        [HttpGet]
        [Route("GetAllDispositivos")]
        public HttpResponseMessage GetAllDispositivos()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IDispositivosInterfazBussines.ListarDispositivosAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllDispositivosUser")]
        public HttpResponseMessage GetAllDispositivosUser(int Id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IDispositivosInterfazBussines.ListarDispositivosAllUser(Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllDispositivosSede")]
        public HttpResponseMessage ListarDispositivosAllSede(int Id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IDispositivosInterfazBussines.ListarDispositivosAllSede(Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearDispositivo")]
        public HttpResponseMessage CrearDispositivo(DispositivosDto dispoDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IDispositivosInterfazBussines.CrearDispositivo(dispoDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("EditarDispositivoId")]
        public HttpResponseMessage EditarDispositivoId(DispositivosDto dispoDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IDispositivosInterfazBussines.EditarDispositivoId(dispoDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("EliminarDispositivo")]
        public HttpResponseMessage EliminarDispositivo(int Id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IDispositivosInterfazBussines.EliminarDispositivo(Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //[HttpGet]
        //[Route("ListarSedeId")]
        //public HttpResponseMessage ListarSedeId(int sede)
        //{
        //    try
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, this._ISedesInterfazBussines.ListarSedeId(sede));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
    }
}
