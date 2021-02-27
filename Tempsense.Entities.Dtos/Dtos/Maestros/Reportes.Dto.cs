using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Maestros
{
    public class ReportesDto
    {
        public int IdDispositivo { get; set; }
        public string Nombre { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? FechaHora { get; set; }
        public string Empresa { get; set; }
    }
}
