using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Bussines.Interfaz.Usuarios;
using Tempsense.Data.Interfaz.Usuarios;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Bussines.Implementacion.Usuarios
{
    public class UsuariosImplementacionBussines : IUsuarioInterfazBussines
    {
        private readonly IUsuariosInterfazData _IUsuariosInterfazData;
        public UsuariosImplementacionBussines(IUsuariosInterfazData IUsuariosInterfazData)
        {
            _IUsuariosInterfazData = IUsuariosInterfazData;
        }

        public UsuariosDto GuardarUsuario(UsuariosDto userDto)
        {
            try
            {
                return this._IUsuariosInterfazData.GuardarUsuario(userDto);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

        public UsuariosDto ValidarEmailUser(string email)
        {
            try
            {
                return this._IUsuariosInterfazData.ValidarEmailUser(email);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

    }
}
