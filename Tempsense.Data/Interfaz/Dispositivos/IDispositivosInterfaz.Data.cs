using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Dispositivos;

namespace Tempsense.Data.Interfaz.Dispositivos
{
    public interface IDispositivosInterfazData
    {
        List<DispositivosDto> ListarDispositivosAll();

        List<DispositivosDto> ListarDispositivosAllUser(int IdUserCompany);

        List<DispositivosDto> ListarDispositivosAllSede(int IdSedeUser);
        bool EditarDispositivoId(DispositivosDto dispositivoDto);
        bool EliminarDispositivo(int IdDisposiotivo);
        DispositivosDto CrearDispositivo(DispositivosDto dispositivoDto);
    }
}
