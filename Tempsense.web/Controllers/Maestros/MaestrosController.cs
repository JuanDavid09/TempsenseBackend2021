using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using Tempsense.Bussines.Interfaz.Maestros;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.web.Controllers.Maestros
{
    public class MaestrosController : ApiController
    {
        private readonly IMaestrosInterfazBussines _IMaestrosInterfazBussines;
        public MaestrosController()
        {

        }

        public MaestrosController(IMaestrosInterfazBussines IMaestrosInterfazBussines)
        {
            _IMaestrosInterfazBussines = IMaestrosInterfazBussines;
        }

        [HttpGet]
        [Route("GetAllMedidas")]
        public HttpResponseMessage GetAllMedidas()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IMaestrosInterfazBussines.ListarMedidas());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("SendMailReport")]
        public HttpResponseMessage SendMailReport(string email, List<ReportesDto> dataReport)
        {
            //string data, string dispositivo, string fechaInicio, string fechaFin, string tiempoFiltro
            try
            {

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("tempsense.sas@outlook.com");

                mail.To.Add(email);
                mail.Subject = "Reporte diario";

                //var resulListMedidas = new List<ReportesDto>();
                //MetodoObtenerTablaSinFiltro(Convert.ToInt16(dispositivo), fechaInicio, fechaFin, Convert.ToInt16(tiempoFiltro));

                // Recorrer la lista y convertirla a html para mostrar

                if (dataReport.Count > 0)
                {
                    String tabla = "<table class='table table-hover' border='1px solid #000' width='500'>";
                    tabla += "<thead>";
                    tabla += "<tr>";
                    tabla += "<th background='#000' color='white'>";
                    tabla += "<strong>Fecha</strong>";
                    tabla += "</th>";
                    tabla += "<th background='#000' color='white'>";
                    tabla += "<strong>Nevera</strong>";
                    tabla += "</th>";
                    tabla += "<th background='#000' color='white'>";
                    tabla += "<strong>Temperatura</strong>";
                    tabla += "</th>";
                    tabla += "</tr>";
                    tabla += "</thead>";
                    tabla += "<tbody>";

                    foreach (var item in dataReport)
                    {
                        tabla += "<tr text-align='center'>";
                        tabla += "<td>" + item.FechaHora + "</td>";
                        tabla += "<td>" + item.Nombre + "</td>";
                        tabla += "<td>" + item.Valor + "</td>";
                        tabla += "</tr>";
                    }
                    tabla += " </tbody>";
                    tabla += "</table>";
                    mail.Body = tabla;
                }
                else
                {
                    mail.Body = "Prueba correo cuerpo";
                }
                //mail.SubjectEncoding = System.Text.Encoding.UTF8;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 25; //465; //587
                smtp.Credentials = new NetworkCredential("tempsense.sas@outlook.com", "IntelControl123");
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                    throw new Exception("No se ha podido enviar el email", ex.InnerException);
                }
                finally
                {
                    smtp.Dispose();
                }

                //MailMessage msg = new MailMessage();
                //msg.To.Add(email);
                //msg.From = new MailAddress("fjblanco1990@gmail.com", "Tempsense S.A.S", System.Text.Encoding.UTF8);
                //msg.Subject = "Reporte diario";
                //msg.SubjectEncoding = System.Text.Encoding.UTF8;

                //var resulListMedidas = new List<Array>();
                //    //MetodoObtenerTablaSinFiltro(Convert.ToInt16(dispositivo), fechaInicio, fechaFin, Convert.ToInt16(tiempoFiltro));

                //// Recorrer la lista y convertirla a html para mostrar

                //if (resulListMedidas.Count > 0)
                //{
                //    String tabla = "<table class='table table-hover' border='1px solid #000' width='500'>";
                //    tabla += "<thead>";
                //    tabla += "<tr>";
                //    tabla += "<th background='#000' color='white'>";
                //    tabla += "<strong>Fecha</strong>";
                //    tabla += "</th>";
                //    tabla += "<th background='#000' color='white'>";
                //    tabla += "<strong>Nevera</strong>";
                //    tabla += "</th>";
                //    tabla += "<th background='#000' color='white'>";
                //    tabla += "<strong>Temperatura</strong>";
                //    tabla += "</th>";
                //    tabla += "</tr>";
                //    tabla += "</thead>";
                //    tabla += "<tbody>";

                //    foreach (var item in resulListMedidas)
                //    {
                //        //tabla += "<tr text-align='center'>";
                //        //tabla += "<td>" + item.Fecha + "</td>";
                //        //tabla += "<td>" + item.NombreDispositivo + "</td>";
                //        //tabla += "<td>" + item.Temperatura + "</td>";
                //        tabla += "</tr>";
                //    }
                //    tabla += " </tbody>";
                //    tabla += "</table>";
                //    msg.Body = tabla;
                //}
                //else
                //{
                //    msg.Body = "";
                //}

                //// aqui construir todo con la nueva informacion
                ////HTMLToString(@"Views\FormatosCorreos\ReportesDiarios.html");

                //msg.BodyEncoding = System.Text.Encoding.UTF8;
                //msg.IsBodyHtml = true;

                ////Aquí es donde se hace lo especial
                //SmtpClient client = new SmtpClient();
                //client.Credentials = new NetworkCredential("fjblanco1990@gmail.com", "(Francisco.1990)");
                //client.Port = 587;
                //client.Host = "smtp.gmail.com";
                //client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
                //try
                //{
                //    client.Send(msg);
                //}
                //catch (System.Net.Mail.SmtpException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    Console.ReadLine();
                //}
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDataReport")]
        public HttpResponseMessage GetDataReport(int user)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IMaestrosInterfazBussines.GetDataReport(user));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDataReporteFiltros")]
        public HttpResponseMessage GetDataReporteFiltros(int ususario, int dispo, DateTime inicio, DateTime fin)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IMaestrosInterfazBussines.GetDataReporteFiltros(ususario, dispo, inicio, fin));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarDataReporteFiltro")]
        public HttpResponseMessage ListarDataReporteFiltro(int ususario, int dispo, DateTime inicio, DateTime fin, int filtro)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, this._IMaestrosInterfazBussines.ListarDataReporteFiltro(ususario, dispo, inicio, fin, filtro));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
