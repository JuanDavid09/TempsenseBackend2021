using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Login;
using Tempsense.Data.Interfaz.Login;
using Tempsense.Entities.Dtos.Dtos.Login;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Bussines.Implementacion.Login
{
    public class LoginImplementacionBussines: ILoginInterfazBussines
    {
        private readonly ILoginInterfazData _ILoginInterfazData;

      
        public LoginImplementacionBussines(ILoginInterfazData ILoginInterfazData)
        {
            _ILoginInterfazData = ILoginInterfazData;
        }

        public LoginReturnDto CrearSessionUsuario(ObjetoSesion sessionUsuario)
        {
            try
            {
                var resultUser = _ILoginInterfazData.ValidarExistenciaUsuario(sessionUsuario);

                if (resultUser != null)
                {
                     return this._ILoginInterfazData.CrearSessionUsuario(sessionUsuario);  
                } 
                else
                {
                    LoginReturnDto objlogin = new LoginReturnDto();
                    objlogin.Mensaje = "El usuario ingresado no existe.";
                    return objlogin;
                }
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool CerrarSesionUsuario(LoginDto objLogin)
        {
            try
            {
                return this._ILoginInterfazData.CerrarSesionUsuario(objLogin);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public bool ValidarSessionUsuario(ValidatorSesionDto validator)
        {
            try
            {
                return this._ILoginInterfazData.ValidarSessionUsuario(validator);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }




    }
}
