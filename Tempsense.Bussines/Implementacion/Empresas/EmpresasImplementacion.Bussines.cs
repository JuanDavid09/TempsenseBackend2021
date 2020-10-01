using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Empresas;
using Tempsense.Data.Interfaz.Empresas;
using Tempsense.Entities.Dtos.Dtos.Empresas;

namespace Tempsense.Bussines.Implementacion.Empresas
{
    public class EmpresasImplementacionBussines: IEmpresasInterfazBussines
    {
        private readonly IEmpresasInterfazData _IEmpresasInterfazData;

        public EmpresasImplementacionBussines(IEmpresasInterfazData IEmpresasInterfazData)
        {
            _IEmpresasInterfazData = IEmpresasInterfazData;
        }

        public List<EmpresasDto> ListarEmpresasAll()
        {
            try
            {
                return this._IEmpresasInterfazData.ListarEmpresasAll();
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        //public EmpresasDto CrearEmpresa(EmpresasDto empresasDto)
        //{
        //    try
        //    {

        //        return this._IEmpresasInterfazData.ListarEmpresasAll();
        //    }
        //    catch (Exception ax)
        //    {
        //        throw new ArgumentException(ax.Message, ax);
        //    }
        //}
    }
}
