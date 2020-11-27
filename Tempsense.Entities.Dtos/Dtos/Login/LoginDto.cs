using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Login
{
    public class ObjetoSesion
    {
        public string Email { get; set; }
        public string password { get; set; }
    }

    public class LoginDto
    {
        public int IdSesionUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string Token { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPerfil { get; set; }
        public int IdSede { get; set; }
        public DateTime FechaInicioSesion { get; set; }
    }

    public class LoginReturnDto
    {
        public int IdSesionUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string Token { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPerfil { get; set; }
        public int IdSede { get; set; }
        public DateTime FechaInicioSesion { get; set; }
        public string Mensaje { get; set; }
    }

    public class ValidatorSesionDto
    {
        public int IdUsuario { get; set; }
        public int IdSesionUsuario { get; set; }
    }
}
