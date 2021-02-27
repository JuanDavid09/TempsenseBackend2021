using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Bussines.Interfaz.Maestros
{
    public interface IMaestrosInterfazBussines
    {
        List<TipoMedidasDto> ListarMedidas();

        List<ReportesDto> GetDataReport(int ususario);
        List<ReportesDto> GetDataReporteFiltros(int ususario, int dispo, DateTime inicio, DateTime fin);
        List<ReportesDto> ListarDataReporteFiltro(int ususario, int dispo, DateTime inicio, DateTime fin, int filtro);



    }
}
