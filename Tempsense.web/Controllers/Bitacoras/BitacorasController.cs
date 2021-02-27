using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Bitacora;
using Tempsense.Entities.Dtos.Dtos.Bitacoras;

namespace Tempsense.web.Controllers.Bitacoras
{
    public class BitacorasController : ApiController
    {
        private readonly IBitacoraInterfazBussines _IBitacoraInterfazBussines;
        public BitacorasController()
        {
                
        }

        public BitacorasController(IBitacoraInterfazBussines IBitacoraInterfazBussines)
        {
            _IBitacoraInterfazBussines = IBitacoraInterfazBussines;
        }

        [HttpGet]
        [Route("GetAllBitacoras")]
        public HttpResponseMessage GetAllBitacoras()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IBitacoraInterfazBussines.ListarBitacorasAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllBitacorasUser")]
        public HttpResponseMessage ListarBitacorasAllUser(int Id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IBitacoraInterfazBussines.ListarBitacorasAllUser(Id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearBitacora")]
        public HttpResponseMessage CrearBitacora(BitacorasDto bitacoraDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IBitacoraInterfazBussines.CrearBitacora(bitacoraDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("EditarBitacoraId")]
        public HttpResponseMessage EditarBitacoraId(BitacorasDto sedesDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IBitacoraInterfazBussines.EditarBitacoraId(sedesDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("EliminarBitacora")]
        public HttpResponseMessage EliminarBitacora(int bitacora)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IBitacoraInterfazBussines.EliminarBitacora(bitacora));
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
