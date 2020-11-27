using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Sedes;

namespace Tempsense.Bussines.Interfaz.Sedes
{
    public interface ISedesInterfazBussines
    {
        List<SedesDto> ListarSedesAll();
        List<SedesDto> ListarSedeId(int idSede);
        bool EditarSedeId(SedesDto sedesDto);
        bool EliminarSede(int idSede);
        SedesDto CrearSede(SedesDto sedesDto);
    }
}
