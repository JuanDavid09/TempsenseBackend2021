using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Bussines.Interfaz.Maestros
{
    public interface IMaestrosInterfazBussines
    {
        List<TipoMedidasDto> ListarMedidas();
    }
}
