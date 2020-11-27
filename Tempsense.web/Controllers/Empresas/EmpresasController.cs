using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Empresas;
using Tempsense.Entities.Dtos.Dtos.Empresas;

namespace Tempsense.web.Controllers.Empresas
{
    public class EmpresasController : ApiController
    {
        private readonly IEmpresasInterfazBussines _IEmpresasInterfazBussines;
        public EmpresasController()
        {

        }
        public EmpresasController(IEmpresasInterfazBussines IEmpresasInterfazBussines)
        {
            _IEmpresasInterfazBussines = IEmpresasInterfazBussines;
        }
       

        [HttpGet]
        [Route("GetAllEmpresas")]
        public HttpResponseMessage GetAllEmpresas()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IEmpresasInterfazBussines.ListarEmpresasAll());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearEmpresa")]
        public HttpResponseMessage CrearEmpresa(EmpresasDto empresasDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IEmpresasInterfazBussines.CrearEmpresa(empresasDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("EditarEmpresaId")]
        public HttpResponseMessage EditarEmpresaId(EmpresasDto empresasDto)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IEmpresasInterfazBussines.EditarEmpresaId(empresasDto));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("EliminarEmpresa")]
        public HttpResponseMessage EliminarEmpresa(int empresa)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IEmpresasInterfazBussines.EliminarEmpresa(empresa));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("ListarEmpresaId")]
        public HttpResponseMessage GetAllEmpresas(int empresa)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IEmpresasInterfazBussines.ListarEmpresaId(empresa));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}