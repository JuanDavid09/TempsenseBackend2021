using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Entities.Dtos.Dtos.Login;

namespace Tempsense.Bussines.Interfaz.Login
{
    public interface ILoginInterfazBussines
    {
        LoginReturnDto CrearSessionUsuario(ObjetoSesion sessionUsuario);
        bool CerrarSesionUsuario(LoginDto objLogin);
        bool ValidarSessionUsuario(ValidatorSesionDto validator);


    }
}
