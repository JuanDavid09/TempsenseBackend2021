
namespace Tempsense.Data.Implementacion.Empresas
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tempsense.Data.Interfaz.Empresas;
    using Tempsense.Entities;
    using Tempsense.Entities.Dtos.Dtos.Empresas;
    public class EmpresasImplementacionData: IEmpresasInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<EmpresasDto> ListarEmpresasAll()
        {
            var resutlSave = _interlControlEntitie.tbl_Empresas.ToList();
            return Mapper.Map<List<EmpresasDto>>(resutlSave);
        }

        public EmpresasDto ListarEmpresaId(int idEmpresa)
        {
            var resutlSave = _interlControlEntitie.tbl_Empresas.Where(c => c.IdEmpresa == idEmpresa).FirstOrDefault();
            return Mapper.Map<EmpresasDto>(resutlSave);
        }

        public bool EditarEmpresaId(EmpresasDto empresasDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Empresas.Where(c => c.IdEmpresa == empresasDto.IdEmpresa).FirstOrDefault();
            resutlSave.Nombre = empresasDto.Nombre;
            resutlSave.Nit = empresasDto.Nit;
            resutlSave.AbrEmpresa = empresasDto.AbrEmpresa;
            resutlSave.Activo = empresasDto.Activo;
            resutlSave.NotificaPorCorreo = empresasDto.NotificaPorCorreo;
            resutlSave.NotificaPorMSM = empresasDto.NotificaPorMSM;
            resutlSave.Correo = empresasDto.Correo;
            _interlControlEntitie.SaveChanges();

            return true;
        }

        public bool EliminarEmpresa(int idEmpresa) 
        { 
            var resutlSave = _interlControlEntitie.tbl_Empresas.Where(c => c.IdEmpresa == idEmpresa).FirstOrDefault();
            _interlControlEntitie.tbl_Empresas.Remove(resutlSave);
            _interlControlEntitie.SaveChanges();
            return true;
        }

        public EmpresasDto CrearEmpresa(EmpresasDto empresasDto)
        {
            var empresaTbl  = Mapper.Map<tbl_Empresas>(empresasDto);
            var resutlSave = _interlControlEntitie.tbl_Empresas.Add(empresaTbl);
            _interlControlEntitie.SaveChanges();
            var empresadto = Mapper.Map<EmpresasDto>(resutlSave);
            return empresadto;
        }

    }
}
