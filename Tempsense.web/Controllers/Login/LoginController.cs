using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Login;
using Tempsense.Bussines.Interfaz.Usuarios;
using Tempsense.Entities.Dtos.Dtos.Login;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.web.Controllers.Login
{
    public class LoginController : ApiController
    {
        private readonly ILoginInterfazBussines _ILoginInterfazBussines;
        private readonly IUsuarioInterfazBussines _IUsuarioInterfazBussines;
        public LoginController()
        {

        }

        public LoginController(ILoginInterfazBussines ILoginInterfazBussines, IUsuarioInterfazBussines IUsuarioInterfazBussines)
        {
            _ILoginInterfazBussines = ILoginInterfazBussines;
            _IUsuarioInterfazBussines = IUsuarioInterfazBussines;
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

        [HttpPost]
        [Route("ValidarSessionUsuario")]
        public HttpResponseMessage ValidarSessionUsuario(ValidatorSesionDto validator)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._ILoginInterfazBussines.ValidarSessionUsuario(validator));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("RecuperarPassword")]
        public HttpResponseMessage RecuperarPassword(string email)
        {
            // aqui validar si el correo existe en BD para enviar la informacion
            UsuariosDto objUser = this._IUsuarioInterfazBussines.ValidarEmailUser(email);

            if (objUser != null)
            {
         

                MailMessage msg = new MailMessage();
                msg.To.Add(email);
                msg.From = new MailAddress("intelcontrol2020@gmail.com", "Tempsense S.A.S", System.Text.Encoding.UTF8);
                msg.Subject = "Recuperacion de contraseña";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                //var resulListMedidas = MetodoObtenerTablaSinFiltro(Convert.ToInt16(dispositivo), fechaInicio, fechaFin, Convert.ToInt16(tiempoFiltro));

                // Recorrer la lista y convertirla a html para mostrar

                String htmlData = "<div>";
                htmlData += "<label>Recuperacion contraseña</label>";
                htmlData += "</div>";
                htmlData += "<div>";
                htmlData += "<br/>";
                htmlData += "<p>Su contraseña es: </p>" + objUser.Passwords;
                htmlData += "<br/>";
                htmlData += "</div>";
                htmlData += "<div>";
                htmlData += "</div>";

                msg.Body = htmlData;

                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;

                try
                {
                    //Aquí es donde se hace lo especial
                    using (SmtpClient client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("intelcontrol2020@gmail.com", "(IntelControl.2020)");
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(msg);
              
                    }
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }


                return Request.CreateResponse(HttpStatusCode.OK); 
            } else {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}