using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Perfiles;

namespace Tempsense.Data.Interfaz.Perfiles
{
    public interface IPerfilesInterfazData
    {
        List<PerfilesDto> GetAllProfiles();
        void Mostrar();
    }
}
