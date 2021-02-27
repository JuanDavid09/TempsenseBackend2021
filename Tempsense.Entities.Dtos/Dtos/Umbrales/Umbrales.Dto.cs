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
        public decimal TemperaturaMin { get; set; }
        public decimal TemperaturaMax { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdDispositivo { get; set; }
        public decimal? ToleranciaMin { get; set; }
        public decimal? ToleranciaMax { get; set; }

    }
}
