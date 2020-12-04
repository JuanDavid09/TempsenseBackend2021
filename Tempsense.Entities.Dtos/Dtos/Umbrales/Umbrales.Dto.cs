using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Umbrales
{
    public class UmbralesDto
    {
        public int IdUmbral { get; set; }
        public decimal Temperatura_min { get; set; }
        public decimal Temperatura_max { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public int IdDispositivo { get; set; }
        public decimal? Tolerancia_min { get; set; }
        public decimal? Tolerancia_max { get; set; }

    }
}
