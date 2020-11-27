using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Umbral;
using Tempsense.Entities.Dtos.Dtos.Umbrales;

namespace Tempsense.web.Controllers.Umbrales
{
    public class UmbralController : ApiController
    {
        private readonly IUmbralInterfazBussines _IUmbralInterfazBussines;
        public UmbralController()
        {

        }
        public UmbralController(IUmbralInterfazBussines IUmbralInterfazBussines)
        {
            _IUmbralInterfazBussines = IUmbralInterfazBussines;
        }

        [HttpGet]
        [Route("GetAllUmbrales")]
        public HttpResponseMessage GetAllUmbrales()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IUmbralInterfazBussines.ListarUmbralesAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearUmbral")]
        public HttpResponseMessage CrearUmbral(UmbralesDto umbralDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IUmbralInterfazBussines.CrearUmbral(umbralDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("EditarUmbralId")]
        public HttpResponseMessage EditarUmbralId(UmbralesDto umbralDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IUmbralInterfazBussines.EditarUmbralId(umbralDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("EliminarUmbral")]
        public HttpResponseMessage EliminarUmbral(int umbral)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IUmbralInterfazBussines.EliminarUmbral(umbral));
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
