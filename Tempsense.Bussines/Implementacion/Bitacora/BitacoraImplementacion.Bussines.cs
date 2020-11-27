using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Bitacora;
using Tempsense.Data.Interfaz.Bitacora;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Bitacoras;

namespace Tempsense.Bussines.Implementacion.Bitacora
{
    public class BitacoraImplementacionBussines: IBitacoraInterfazBussines
    {
        private readonly IBitacoraInterfazData _IBitacoraInterfazData;
        public BitacoraImplementacionBussines(IBitacoraInterfazData IBitacoraInterfazData)
        {
            _IBitacoraInterfazData = IBitacoraInterfazData;
        }

        public List<BitacorasDto> ListarBitacorasAll()
        {
            try
            {
                return this._IBitacoraInterfazData.ListarBitacorasAll();
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

        public bool EditarBitacoraId(BitacorasDto bitacoraDto)
        {
            try
            {

                return this._IBitacoraInterfazData.EditarBitacoraId(bitacoraDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EliminarBitacora(int idBitacora)
        {
            try
            {

                return this._IBitacoraInterfazData.EliminarBitacora(idBitacora);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public BitacorasDto CrearBitacora(BitacorasDto bitacoraDto)
        {
            try
            {

                return this._IBitacoraInterfazData.CrearBitacora(bitacoraDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }
    }
}
