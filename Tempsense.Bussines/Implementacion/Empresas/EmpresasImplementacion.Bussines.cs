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

        public EmpresasDto CrearEmpresa(EmpresasDto empresasDto)
        {
            try
            {

                return this._IEmpresasInterfazData.CrearEmpresa(empresasDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EditarEmpresaId(EmpresasDto empresasDto)
        {
            try
            {

                return this._IEmpresasInterfazData.EditarEmpresaId(empresasDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public EmpresasDto ListarEmpresaId(int idEmpresa)
        {
            try
            {

                return this._IEmpresasInterfazData.ListarEmpresaId(idEmpresa);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EliminarEmpresa(int idEmpresa)
        {
            try
            {
                return this._IEmpresasInterfazData.EliminarEmpresa(idEmpresa);
            }
            catch (Exception ax)
            {
                return false;
                throw new ArgumentException(ax.Message, ax.InnerException.InnerException.Message);
            }
        }
    }
}
