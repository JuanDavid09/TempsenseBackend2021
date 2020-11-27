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

        //public List<UmbralesDto> ListarSedeId(int idSede)
        //{
        //    var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.Id == idSede).ToList();
        //    return Mapper.Map<List<UmbralesDto>>(resutlSave);
        //}

        public bool EditarUmbralId(UmbralesDto umbralDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.IdUmbral == umbralDto.IdUmbral).FirstOrDefault();
            resutlSave.Temperatura_max = umbralDto.Temperatura_max;
            resutlSave.Temperatura_min = umbralDto.Temperatura_min;
            resutlSave.Tolerancia_max = umbralDto.Tolerancia_max;
            resutlSave.Tolerancia_min = umbralDto.Tolerancia_min;
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
            var resutlSave = _interlControlEntitie.tbl_Umbrales.Add(umbralTbl);
            _interlControlEntitie.SaveChanges();
            var empresadto = Mapper.Map<UmbralesDto>(resutlSave);
            return empresadto;
        }
    }
}
