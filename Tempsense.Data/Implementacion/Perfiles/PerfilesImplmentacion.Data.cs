namespace Tempsense.Data.Implementacion.Perfiles
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tempsense.Data.Interfaz.Perfiles;
    using Tempsense.Entities;
    using Tempsense.Entities.Dtos.Dtos.Perfiles;

    public class PerfilesImplmentacionData: IPerfilesInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<PerfilesDto> GetAllProfiles()
        {
            var resutlSave = _interlControlEntitie.tbl_Perfiles.ToList();
            var resutlMapper =  Mapper.Map<List<PerfilesDto>>(resutlSave);
            return resutlMapper;
        }

        public void Mostrar()
        {

        }
    }
}
