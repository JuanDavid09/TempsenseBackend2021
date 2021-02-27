using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Umbral;
using Tempsense.Data.Interfaz.Umbral;
using Tempsense.Entities.Dtos.Dtos.Umbrales;

namespace Tempsense.Bussines.Implementacion.Umbral
{
    public class UmbralImplementacionBussines: IUmbralInterfazBussines
    {
        private readonly IUmbralInterfazData _IUmbralInterfazData;
        public UmbralImplementacionBussines(IUmbralInterfazData IUmbralInterfazData)
        {
            _IUmbralInterfazData = IUmbralInterfazData;
        }

        public List<UmbralesDto> ListarUmbralesAll()
        {
            try
            {
                return this._IUmbralInterfazData.ListarUmbralesAll();
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public List<UmbralesDto> ListarUmbralesAllUser(int IdUser)
        {
            try
            {
                return this._IUmbralInterfazData.ListarUmbralesAllUser(IdUser);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        //public List<DispositivosDto> ListarSedeId(int idSede)
        //{
        //    try
        //    {
        //        return this._IDispositivosInterfazData.ListarSedeId(idSede);
        //    }
        //    catch (Exception ax)
        //    {
        //        throw new ArgumentException(ax.Message, ax);
        //    }
        //}

        public bool EditarUmbralId(UmbralesDto umbralDto)
        {
            try
            {

                return this._IUmbralInterfazData.EditarUmbralId(umbralDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EliminarUmbral(int idUmbral)
        {
            try
            {

                return this._IUmbralInterfazData.EliminarUmbral(idUmbral);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public UmbralesDto CrearUmbral(UmbralesDto dispositivosDto)
        {
            try
            {

                return this._IUmbralInterfazData.CrearUmbral(dispositivosDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

    }
}
