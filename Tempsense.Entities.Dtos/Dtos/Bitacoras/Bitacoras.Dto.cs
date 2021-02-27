using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempsense.Entities.Dtos.Dtos.Bitacoras
{
    public class BitacorasDto
    {
        public int IdBitacora { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }
        public int IdDispositivo { get; set; }
        public string Responsable { get; set; }
        public DateTime? guardadodebitacora { get; set; }
    }
}
