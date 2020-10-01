using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Perfiles;

namespace Tempsense.Bussines.Interfaz.Perfiles
{
    public interface IPerfilesInterfazBussines
    {
        List<PerfilesDto> GetAllProfiles();
    }
}
