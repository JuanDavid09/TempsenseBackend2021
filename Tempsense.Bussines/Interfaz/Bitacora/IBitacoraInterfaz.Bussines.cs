using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Bitacoras;

namespace Tempsense.Bussines.Interfaz.Bitacora
{
    public interface IBitacoraInterfazBussines
    {
        List<BitacorasDto> ListarBitacorasAll();
        List<BitacorasDto> ListarBitacorasAllUser(int IdUserCompany);
        bool EditarBitacoraId(BitacorasDto bitacoraDto);
        bool EliminarBitacora(int idBitacora);
        BitacorasDto CrearBitacora(BitacorasDto bitacoraDto);
    }
}
