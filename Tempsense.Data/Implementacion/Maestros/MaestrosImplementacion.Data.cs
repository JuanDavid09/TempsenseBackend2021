using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Maestros;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Data.Implementacion.Maestros
{
    public class MaestrosImplementacionData : IMaestrosInterfazData
    {
        private const int FiltroDias = 1440;

        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<TipoMedidasDto> ListarMedidas()
        {
            var resutlSave = _interlControlEntitie.tbl_TipoMedidas.ToList();
            return Mapper.Map<List<TipoMedidasDto>>(resutlSave);
        }

        public List<ReportesDto> GetDataReport(int ususario)
        {
            var resutlSave = (from emp in _interlControlEntitie.tbl_Empresas
                              join sed in _interlControlEntitie.tbl_Sedes on emp.IdEmpresa equals sed.IdEmpresa
                              join sedUs in _interlControlEntitie.tbl_UsuariosXSedes on sed.IdSede equals sedUs.IdSede
                              join dis in _interlControlEntitie.tbl_Dispositivos on sedUs.IdSede equals dis.IdSede
                              join usu in _interlControlEntitie.tbl_Usuarios on sedUs.IdUsuario equals usu.IdUsuario
                              join ultMed in _interlControlEntitie.tbl_UltimasMedidas on dis.IdDispositivo equals ultMed.DispositivoID
                              where usu.IdUsuario == ususario
                              select new ReportesDto
                              {
                                  Empresa = emp.Nombre,
                                  IdDispositivo = dis.IdDispositivo,
                                  FechaHora = ultMed.FechaHora,
                                  Nombre = dis.Nombre,
                                  Valor = ultMed.Valor
                              }).ToList();

            return resutlSave;
        }

        public List<ReportesDto> GetDataReporteFiltros(int ususario,int dispo, DateTime fechaInicio, DateTime fechaFin)
        {
            var resutlSave = (from emp in _interlControlEntitie.tbl_Empresas
                              join sed in _interlControlEntitie.tbl_Sedes on emp.IdEmpresa equals sed.IdEmpresa
                              join sedUs in _interlControlEntitie.tbl_UsuariosXSedes on sed.IdSede equals sedUs.IdSede
                              join dis in _interlControlEntitie.tbl_Dispositivos on sedUs.IdSede equals dis.IdSede
                              join usu in _interlControlEntitie.tbl_Usuarios on sedUs.IdUsuario equals usu.IdUsuario
                              join ultMed in _interlControlEntitie.tbl_UltimasMedidas on dis.IdDispositivo equals ultMed.DispositivoID
                              where usu.IdUsuario == ususario && dis.IdDispositivo == dispo && (ultMed.FechaHora >= fechaInicio && ultMed.FechaHora <= fechaFin)
                              select new ReportesDto
                              {
                                  Empresa = emp.Nombre,
                                  IdDispositivo = dis.IdDispositivo,
                                  FechaHora = ultMed.FechaHora,
                                  Nombre = dis.Nombre,
                                  Valor = ultMed.Valor
                              }).ToList();

            return resutlSave;
        }

        public List<ReportesDto> ListarDataReporteFiltro(int ususario, int dispo, DateTime? fechaInicio, DateTime? fechaFin, int filtro)
        {
            var resutlSave = (from emp in _interlControlEntitie.tbl_Empresas
                              join sed in _interlControlEntitie.tbl_Sedes on emp.IdEmpresa equals sed.IdEmpresa
                              join sedUs in _interlControlEntitie.tbl_UsuariosXSedes on sed.IdSede equals sedUs.IdSede
                              join dis in _interlControlEntitie.tbl_Dispositivos on sedUs.IdSede equals dis.IdSede
                              join usu in _interlControlEntitie.tbl_Usuarios on sedUs.IdUsuario equals usu.IdUsuario
                              join ultMed in _interlControlEntitie.tbl_UltimasMedidas on dis.IdDispositivo equals ultMed.DispositivoID
                              where usu.IdUsuario == ususario && dis.IdDispositivo == dispo && (ultMed.FechaHora >= fechaInicio && ultMed.FechaHora <= fechaFin)
                              //&& (ultMed.FechaHora.Value.Hour => )
                              select new ReportesDto
                              {
                                  Empresa = emp.Nombre,
                                  IdDispositivo = dis.IdDispositivo,
                                  FechaHora = ultMed.FechaHora,
                                  Nombre = dis.Nombre,
                                  Valor = ultMed.Valor
                              }).ToList();

            return resutlSave;
        }

    }
}
