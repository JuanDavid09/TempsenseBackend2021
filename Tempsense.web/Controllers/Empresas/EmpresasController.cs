using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Empresas;

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
    }
}