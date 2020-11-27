using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Maestros;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Maestros;

namespace Tempsense.Data.Implementacion.Maestros
{
    public class MaestrosImplementacionData: IMaestrosInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public List<TipoMedidasDto> ListarMedidas()
        {
            var resutlSave = _interlControlEntitie.tbl_TipoMedidas.ToList();
            return Mapper.Map<List<TipoMedidasDto>>(resutlSave);
        }

    }
}
