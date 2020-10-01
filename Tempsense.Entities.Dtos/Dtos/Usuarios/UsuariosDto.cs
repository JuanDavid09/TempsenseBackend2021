using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Usuarios
{
    public class UsuariosDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Passwords { get; set; }
        public string Telefono { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPerfil { get; set; }
        public string Email { get; set; }
    }
}
