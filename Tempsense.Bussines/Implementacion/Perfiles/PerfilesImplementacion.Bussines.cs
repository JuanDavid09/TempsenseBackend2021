using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Perfiles;
using Tempsense.Data.Interfaz.Perfiles;
using Tempsense.Entities.Dtos.Dtos.Perfiles;

namespace Tempsense.Bussines.Implementacion.Perfiles
{
    public class PerfilesImplementacionBussines: IPerfilesInterfazBussines
    {
        private readonly IPerfilesInterfazData _IPerfilesInterfazData;

        public PerfilesImplementacionBussines(IPerfilesInterfazData IPerfilesInterfazData)
        {
            _IPerfilesInterfazData = IPerfilesInterfazData;
        }

        public List<PerfilesDto> GetAllProfiles()
        {
            return this._IPerfilesInterfazData.GetAllProfiles();
        }
    }
}
