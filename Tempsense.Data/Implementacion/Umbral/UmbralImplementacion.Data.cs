using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Umbral;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Umbrales;

namespace Tempsense.Data.Implementacion.Umbral
{
    public class UmbralImplementacionData: IUmbralInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<UmbralesDto> ListarUmbralesAll()
        {
            var resutlSave = _interlControlEntitie.tbl_Umbrales.ToList();
            return Mapper.Map<List<UmbralesDto>>(resutlSave);
        }

        public List<UmbralesDto> ListarUmbralesAllUser(int IdUserCompany)
        {
            var resutlSave = (from us in _interlControlEntitie.tbl_Usuarios
                              join uxs in _interlControlEntitie.tbl_UsuariosXSedes on us.IdUsuario equals uxs.IdUsuario
                              join se in _interlControlEntitie.tbl_Sedes on uxs.IdSede equals se.IdSede
                              join di in _interlControlEntitie.tbl_Dispositivos on se.IdSede equals di.IdSede
                              join um in _interlControlEntitie.tbl_Umbrales on di.IdDispositivo equals um.IdDispositivo
                              where us.IdUsuario ==  IdUserCompany
                              select um).ToList();


            return Mapper.Map<List<UmbralesDto>>(resutlSave);
        }

        //public List<UmbralesDto> ListarSedeId(int idSede)
        //{
        //    var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.Id == idSede).ToList();
        //    return Mapper.Map<List<UmbralesDto>>(resutlSave);
        //}

        public bool EditarUmbralId(UmbralesDto umbralDto)
        {

            var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.IdUmbral == umbralDto.IdUmbral).FirstOrDefault();
            resutlSave.TemperaturaMax = umbralDto.TemperaturaMax;
            resutlSave.TemperaturaMin = umbralDto.TemperaturaMin;
            resutlSave.ToleranciaMax = umbralDto.TemperaturaMax;
            resutlSave.ToleranciaMin = umbralDto.ToleranciaMin;
            resutlSave.IdDispositivo = umbralDto.IdDispositivo;

            _interlControlEntitie.SaveChanges();

            return true;
        }

        public bool EliminarUmbral(int idUmbral)
        {
            var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.IdUmbral == idUmbral).FirstOrDefault();
            _interlControlEntitie.tbl_Umbrales.Remove(resutlSave);
            _interlControlEntitie.SaveChanges();
            return true;
        }

        public UmbralesDto CrearUmbral(UmbralesDto umbralDto)
        {

            var umbralTbl = Mapper.Map<tbl_Umbrales>(umbralDto);
            umbralTbl.Activo = true;
            umbralTbl.FechaInicio = DateTime.Now;
            var resutlSave = _interlControlEntitie.tbl_Umbrales.Add(umbralTbl);
            _interlControlEntitie.SaveChanges();
            var empresadto = Mapper.Map<UmbralesDto>(resutlSave);
            return empresadto;
        }
    }
}
