using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Login;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Data.Interfaz.Login
{
    public interface ILoginInterfazData
    {
        UsuariosDto ValidarExistenciaUsuario(ObjetoSesion sessionUsuario);
        LoginReturnDto CrearSessionUsuario(ObjetoSesion sessionUsuario);
        bool CerrarSesionUsuario(LoginDto objLogin);
        bool ValidarSessionUsuario(ValidatorSesionDto validator);

    }
}
