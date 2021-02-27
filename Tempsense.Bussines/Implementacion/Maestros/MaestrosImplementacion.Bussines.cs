using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Maestros;
using Tempsense.Data.Interfaz.Maestros;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Bussines.Implementacion.Maestros
{
    public class MaestrosImplementacionBussines: IMaestrosInterfazBussines
    {
        private readonly IMaestrosInterfazData _IMaestrosInterfazData;
        public MaestrosImplementacionBussines(IMaestrosInterfazData IMaestrosInterfazData)
        {
            _IMaestrosInterfazData = IMaestrosInterfazData;
        }

        public List<TipoMedidasDto> ListarMedidas()
        {
            try
            {
                return this._IMaestrosInterfazData.ListarMedidas();
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public List<ReportesDto> GetDataReport(int ususario)
        {
            try
            {
                return this._IMaestrosInterfazData.GetDataReport(ususario);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public List<ReportesDto> ListarDataReporteFiltro(int ususario, int dispo, DateTime inicio, DateTime fin, int filtro)
        {
            try
            {
                return this._IMaestrosInterfazData.ListarDataReporteFiltro(ususario, dispo, inicio, fin, filtro);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public List<ReportesDto> GetDataReporteFiltros(int ususario, int dispo, DateTime inicio, DateTime fin)
        {
            try
            {
                return this._IMaestrosInterfazData.GetDataReporteFiltros(ususario, dispo, inicio, fin);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }
    }
}
