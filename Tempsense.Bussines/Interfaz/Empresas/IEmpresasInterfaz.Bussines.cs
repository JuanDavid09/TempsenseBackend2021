using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Empresas;

namespace Tempsense.Bussines.Interfaz.Empresas
{
    public interface IEmpresasInterfazBussines
    {
        List<EmpresasDto> ListarEmpresasAll();
    }
}
