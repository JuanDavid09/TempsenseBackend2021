using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Data.Interfaz.Maestros
{
    public interface IMaestrosInterfazData
    {
        List<TipoMedidasDto> ListarMedidas();

        List<ReportesDto> GetDataReport(int ususario);

        List<ReportesDto> GetDataReporteFiltros(int ususario, int dispo, DateTime fechaInicio, DateTime fechaFin);

        List<ReportesDto> ListarDataReporteFiltro(int ususario, int dispo, DateTime? fechaInicio, DateTime? fechaFin, int filtro);
    }
}
