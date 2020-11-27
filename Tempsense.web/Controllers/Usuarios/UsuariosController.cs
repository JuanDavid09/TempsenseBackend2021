﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Usuarios;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.web.Controllers.Usuarios
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioInterfazBussines _IUsuarioInterfazBussines;
        public UsuariosController()
        {

        }

        public UsuariosController(IUsuarioInterfazBussines IUsuarioInterfazBussines)
        {
            this._IUsuarioInterfazBussines = IUsuarioInterfazBussines;
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public HttpResponseMessage GuardarUsuario(UsuariosDto userDto)
        {
            try
            {
                UsuariosDto objUser = this._IUsuarioInterfazBussines.ValidarEmailUser(userDto.Email);
                if (objUser == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, this._IUsuarioInterfazBussines.GuardarUsuario(userDto)); 
                } else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}