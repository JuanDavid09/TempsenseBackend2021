using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Bussines.Interfaz.Usuarios
{
    public interface IUsuarioInterfazBussines
    {
        UsuariosDto GuardarUsuario(UsuariosDto userDto);

        UsuariosDto ValidarEmailUser(string email);
    }
}
