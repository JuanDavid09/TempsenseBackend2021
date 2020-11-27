using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Dispositivos;

namespace Tempsense.Bussines.Interfaz.Dispositivos
{
    public interface IDispositivosInterfazBussines
    {
        List<DispositivosDto> ListarDispositivosAll();
        bool EditarDispositivoId(DispositivosDto dispositivoDto);
        bool EliminarDispositivo(int IdDisposiotivo);
        DispositivosDto CrearDispositivo(DispositivosDto dispositivoDto);
    }
}
