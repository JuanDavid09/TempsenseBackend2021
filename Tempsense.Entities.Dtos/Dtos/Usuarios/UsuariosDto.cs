using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Empresas;
using Tempsense.Entities.Dtos.Dtos.Perfiles;
using Tempsense.Entities.Dtos.Dtos.Sedes;

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

        public List<SedesDto> sedes { get; set; }
    }

    public class UsuariosStrDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Passwords { get; set; }
        public string Telefono { get; set; }
        public EmpresasDto IdEmpresa { get; set; }
        public PerfilesDto IdPerfil { get; set; }
        public string Email { get; set; }

        public List<SedesDto> sedes { get; set; }
    }
}
