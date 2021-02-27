using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Umbrales;

namespace Tempsense.Data.Interfaz.Umbral
{
    public interface IUmbralInterfazData
    {
        List<UmbralesDto> ListarUmbralesAll();

        List<UmbralesDto> ListarUmbralesAllUser(int IdUserCompany);
        bool EditarUmbralId(UmbralesDto umbralDto);
        bool EliminarUmbral(int idUmbral);
        UmbralesDto CrearUmbral(UmbralesDto umbralDto);
    }
}
