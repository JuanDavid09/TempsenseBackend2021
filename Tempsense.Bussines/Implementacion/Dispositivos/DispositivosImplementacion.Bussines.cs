using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Dispositivos;
using Tempsense.Data.Interfaz.Dispositivos;
using Tempsense.Entities.Dtos.Dtos.Dispositivos;

namespace Tempsense.Bussines.Implementacion.Dispositivos
{
    public class DispositivosImplementacionBussines: IDispositivosInterfazBussines
    {
        private readonly IDispositivosInterfazData _IDispositivosInterfazData;
        public DispositivosImplementacionBussines(IDispositivosInterfazData IDispositivosInterfazData)
        {
            _IDispositivosInterfazData = IDispositivosInterfazData;
        }
        public List<DispositivosDto> ListarDispositivosAll()
        {
            try
            {
                return this._IDispositivosInterfazData.ListarDispositivosAll();
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

        public bool EditarDispositivoId(DispositivosDto dispositivosDto)
        {
            try
            {

                return this._IDispositivosInterfazData.EditarDispositivoId(dispositivosDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EliminarDispositivo(int idDispositivo)
        {
            try
            {

                return this._IDispositivosInterfazData.EliminarDispositivo(idDispositivo);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public DispositivosDto CrearDispositivo(DispositivosDto dispositivosDto)
        {
            try
            {

                return this._IDispositivosInterfazData.CrearDispositivo(dispositivosDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }
    }
}
