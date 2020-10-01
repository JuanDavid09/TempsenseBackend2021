using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Data.Interfaz.Usuarios
{
    public interface IUsuariosInterfazData
    {
        UsuariosDto GuardarUsuario(UsuariosDto userDto);
    }
}
