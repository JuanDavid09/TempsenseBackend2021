using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Contactenos;
using Tempsense.Entities;

namespace Tempsense.Data.Implementacion.Contactenos
{
    public class ContactenosImplementacionData: IContactenosInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();
    }
}
