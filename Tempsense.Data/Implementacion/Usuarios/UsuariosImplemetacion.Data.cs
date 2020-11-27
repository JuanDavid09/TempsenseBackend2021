using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Usuarios;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Data.Implementacion.Usuarios
{
    public class UsuariosImplemetacionData: IUsuariosInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();
         
        public UsuariosDto  GuardarUsuario (UsuariosDto userDto)
        {
            var resutlSave =_interlControlEntitie.tbl_Usuarios.Add(Mapper.Map<tbl_Usuarios>(userDto));
            _interlControlEntitie.SaveChanges();
            return Mapper.Map<UsuariosDto>(resutlSave);
        }

        public UsuariosDto ValidarEmailUser(string email)
        {
            try
            {
                tbl_Usuarios objUserTable =  this._interlControlEntitie.tbl_Usuarios.Where(c => c.Email.Equals(email)).FirstOrDefault();
                return Mapper.Map<UsuariosDto>(objUserTable);
            }
            catch (Exception ax)
            {
                throw new ArgumentException(ax.Message, ax);
            }
        }

    }
}
