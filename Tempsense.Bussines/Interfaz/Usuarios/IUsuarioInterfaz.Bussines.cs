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
        bool EliminarUsuario(int IdUser);
        bool EditarUsuario(UsuariosDto userDto);
        List<UsuariosStrDto> GetAllUsuarios();
        UsuariosDto ValidarEmailUser(string email);
    }
}
