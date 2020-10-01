using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Empresas
{
    public class EmpresasDto
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Abr_Empresa { get; set; }
        public string Nit { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public bool NotificaPorCorreo { get; set; }
        public bool NotificaPorMSM { get; set; }
    }
}
