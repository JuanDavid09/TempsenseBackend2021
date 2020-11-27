using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Dispositivos
{
    public class DispositivosDto
    {
        public int IdDispositivo { get; set; }
        public string Nombre { get; set; }
        public int IdTipoMedida { get; set; }
        public int IdSede { get; set; }
        public int TiempoNotificacion { get; set; }
        public bool Activo { get; set; }
    }
}
