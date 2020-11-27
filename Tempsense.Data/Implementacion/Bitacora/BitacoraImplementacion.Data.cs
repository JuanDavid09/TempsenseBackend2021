using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Bitacora;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Bitacoras;

namespace Tempsense.Data.Implementacion.Bitacora
{
    public class BitacoraImplementacionData: IBitacoraInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<BitacorasDto> ListarBitacorasAll()
        {
            var resutlSave = _interlControlEntitie.tbl_Bitacoras.ToList();
            return Mapper.Map<List<BitacorasDto>>(resutlSave);
        }

        //public List<UmbralesDto> ListarSedeId(int idSede)
        //{
        //    var resutlSave = _interlControlEntitie.tbl_Umbrales.Where(c => c.Id == idSede).ToList();
        //    return Mapper.Map<List<UmbralesDto>>(resutlSave);
        //}

        public bool EditarBitacoraId(BitacorasDto bitacoraDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Bitacoras.Where(c => c.IdBitacora == bitacoraDto.IdBitacora).FirstOrDefault();
            resutlSave.Fecha = bitacoraDto.Fecha;
            resutlSave.HoraInicio = bitacoraDto.HoraInicio;
            resutlSave.HoraFin = bitacoraDto.HoraFin;
            resutlSave.IdDispositivo = bitacoraDto.IdDispositivo;
            resutlSave.Problema = bitacoraDto.Problema;
            resutlSave.Responsable = bitacoraDto.Responsable;
            resutlSave.Solucion = bitacoraDto.Solucion;

            _interlControlEntitie.SaveChanges();

            return true;
        }

        public bool EliminarBitacora(int idBitacora)
        {
            var resutlSave = _interlControlEntitie.tbl_Bitacoras.Where(c => c.IdBitacora == idBitacora).FirstOrDefault();
            _interlControlEntitie.tbl_Bitacoras.Remove(resutlSave);
            _interlControlEntitie.SaveChanges();
            return true;
        }

        public BitacorasDto CrearBitacora(BitacorasDto bitacoraDto)
        {
            var bitacoraTbl = Mapper.Map<tbl_Bitacoras>(bitacoraDto);
            var resutlSave = _interlControlEntitie.tbl_Bitacoras.Add(bitacoraTbl);
            _interlControlEntitie.SaveChanges();
            var empresadto = Mapper.Map<BitacorasDto>(resutlSave);
            return empresadto;
        }
    }
}
