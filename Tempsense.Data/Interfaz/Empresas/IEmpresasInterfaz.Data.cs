using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Empresas;

namespace Tempsense.Data.Interfaz.Empresas
{
    public interface IEmpresasInterfazData
    {
        List<EmpresasDto> ListarEmpresasAll();
    }
}
