using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Sedes;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Sedes;

namespace Tempsense.Data.Implementacion.Sedes
{
    public class SedesImplementacionData: ISedeInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();


        public List<SedesDto> ListarSedesAll()
        {
            var resutlSave = _interlControlEntitie.tbl_Sedes.ToList();
            return Mapper.Map<List<SedesDto>>(resutlSave);
        }

        public List<SedesDto> ListarSedeId(int idSede)
        {
            var resutlSave = _interlControlEntitie.tbl_Sedes.Where(c => c.IdEmpresa == idSede).ToList();
            return Mapper.Map<List<SedesDto>>(resutlSave);
        }

        public bool EditarSedeId(SedesDto sedesDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Sedes.Where(c => c.IdSede == sedesDto.IdSede).FirstOrDefault();
            resutlSave.Nombre = sedesDto.Nombre;
            resutlSave.IdEmpresa = sedesDto.IdEmpresa;

            _interlControlEntitie.SaveChanges();

            return true;
        }

        public bool EliminarSede(int idSede)
        {
            var resutlSave = _interlControlEntitie.tbl_Sedes.Where(c => c.IdSede == idSede).FirstOrDefault();
            _interlControlEntitie.tbl_Sedes.Remove(resutlSave);
            _interlControlEntitie.SaveChanges();
            return true;
        }

        public SedesDto CrearSede(SedesDto sedesDto)
        {
            var sedesTbl = Mapper.Map<tbl_Sedes>(sedesDto);
            var resutlSave = _interlControlEntitie.tbl_Sedes.Add(sedesTbl);
            _interlControlEntitie.SaveChanges();
            var empresadto = Mapper.Map<SedesDto>(resutlSave);
            return empresadto;
        }

    }
}
