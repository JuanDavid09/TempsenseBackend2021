using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Sedes;
using Tempsense.Data.Interfaz.Sedes;
using Tempsense.Entities.Dtos.Dtos.Sedes;

namespace Tempsense.Bussines.Implementacion.Sedes
{
    public class SedesImplementacionBussines: ISedesInterfazBussines
    {
        private readonly ISedeInterfazData _ISedeInterfazData;
        public SedesImplementacionBussines(ISedeInterfazData ISedeInterfazData)
        {
            this._ISedeInterfazData = ISedeInterfazData;
        }
        public List<SedesDto> ListarSedesAll()
        {
            try
            {
                return this._ISedeInterfazData.ListarSedesAll();
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public List<SedesDto> ListarSedeId(int idSede)
        {
            try
            {
                return this._ISedeInterfazData.ListarSedeId(idSede);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EditarSedeId(SedesDto sedesDto)
        {
            try
            {

                return this._ISedeInterfazData.EditarSedeId(sedesDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool EliminarSede(int idSede)
        {
            try
            {

                return this._ISedeInterfazData.EliminarSede(idSede);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        } 
        
        public SedesDto CrearSede(SedesDto sedesDto)
        {
            try
            {

                return this._ISedeInterfazData.CrearSede(sedesDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }
    }
}
