using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Umbral;
using Tempsense.Entities;

namespace Tempsense.Data.Implementacion.Umbral
{
    public class UmbrelImplementacionData: IUmbralInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();
    }
}
