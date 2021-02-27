using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Dispositivos;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Dispositivos;

namespace Tempsense.Data.Implementacion.Dispositivos
{
    public class DispositivosImplementacionData: IDispositivosInterfazData
    {

        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<DispositivosDto> ListarDispositivosAll()
        {
            var resutlSave = _interlControlEntitie.tbl_Dispositivos.ToList();
            return Mapper.Map<List<DispositivosDto>>(resutlSave);
        }

        public List<DispositivosDto> ListarDispositivosAllUser(int IdUserCompany)
        {
            var resutlSave = (from us in _interlControlEntitie.tbl_Usuarios
                              join uxs in _interlControlEntitie.tbl_UsuariosXSedes on us.IdUsuario equals uxs.IdUsuario
                              join se in _interlControlEntitie.tbl_Sedes on uxs.IdSede equals se.IdSede
                              join di in _interlControlEntitie.tbl_Dispositivos on se.IdSede equals di.IdSede
                              where us.IdUsuario == IdUserCompany
                              select di).ToList();

            return Mapper.Map<List<DispositivosDto>>(resutlSave);
        }

        public List<DispositivosDto> ListarDispositivosAllSede(int IdSedeUser)
        {

            var resutlSave = (from us in _interlControlEntitie.tbl_Usuarios
                              join uxs in _interlControlEntitie.tbl_UsuariosXSedes on us.IdUsuario equals uxs.IdUsuario
                              join se in _interlControlEntitie.tbl_Sedes on uxs.IdSede equals se.IdSede
                              join di in _interlControlEntitie.tbl_Dispositivos on se.IdSede equals di.IdSede
                              where se.IdSede == IdSedeUser
                              group di by new { di.IdDispositivo, di.Nombre, di.IdTipoMedida, di.TiempoNotificacion, di.Activo, di.IdSede } into grupo
                              select new DispositivosDto {
                                  Activo = grupo.Key.Activo,
                                  IdDispositivo = grupo.Key.IdDispositivo,
                                  IdSede = grupo.Key.IdSede,
                                  IdTipoMedida = grupo.Key.IdTipoMedida,
                                  Nombre = grupo.Key.Nombre,
                                  TiempoNotificacion = grupo.Key.TiempoNotificacion
                              }).ToList();
            return (resutlSave);
        }

        //public List<UmbralesDto> ListarSedeId(int idSede)
        //{
        //    var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.Id == idSede).ToList();
        //    return Mapper.Map<List<UmbralesDto>>(resutlSave);
        //}

        public bool EditarDispositivoId(DispositivosDto dispositivoDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Dispositivos.Where(c => c.IdDispositivo == dispositivoDto.IdDispositivo).FirstOrDefault();
            resutlSave.Nombre = dispositivoDto.Nombre;
            resutlSave.IdTipoMedida = dispositivoDto.IdTipoMedida;
            resutlSave.IdSede = dispositivoDto.IdSede;
            resutlSave.TiempoNotificacion = dispositivoDto.TiempoNotificacion;
            resutlSave.Activo = dispositivoDto.Activo;

            _interlControlEntitie.SaveChanges();

            return true;
        }

        public bool EliminarDispositivo(int IdDisposiotivo)
        {
            var resutlSave = _interlControlEntitie.tbl_Dispositivos.Where(c => c.IdDispositivo == IdDisposiotivo).FirstOrDefault();
            _interlControlEntitie.tbl_Dispositivos.Remove(resutlSave);
            _interlControlEntitie.SaveChanges();
            return true;
        }

        public DispositivosDto CrearDispositivo(DispositivosDto dispositivoDto)
        {
            var dispoTbl = Mapper.Map<tbl_Dispositivos>(dispositivoDto);
            var resutlSave = _interlControlEntitie.tbl_Dispositivos.Add(dispoTbl);
            _interlControlEntitie.SaveChanges();
            var empresadto = Mapper.Map<DispositivosDto>(resutlSave);
            return empresadto;
        }
    }
}
