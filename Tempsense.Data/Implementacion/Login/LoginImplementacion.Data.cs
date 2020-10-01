using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Login;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Login;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Data.Implementacion.Login
{
    public class LoginImplementacionData: ILoginInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public UsuariosDto ValidarExistenciaUsuario(ObjetoSesion sessionUsuario)
        {
            var objUsuario = _interlControlEntitie.tbl_Usuarios.Where(c => c.Email.Equals(sessionUsuario.Email) && c.Passwords.Equals(sessionUsuario.password)).FirstOrDefault();
            return Mapper.Map<UsuariosDto>(objUsuario);
        }

        public LoginReturnDto CrearSessionUsuario(ObjetoSesion sessionUsuario)
        {
            var objUsuario = _interlControlEntitie.tbl_Usuarios.Where(c => c.Email.Equals(sessionUsuario.Email) &&
            c.Passwords.Equals(sessionUsuario.password)).FirstOrDefault();

            LoginDto objLoginSession = new LoginDto();
            objLoginSession.IdUsuario = objUsuario.IdUsuario;
            objLoginSession.FechaInicioSesion = System.DateTime.Now;
            objLoginSession.Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            objLoginSession.IdEmpresa = objUsuario.IdEmpresa;
           
            var objSession = Mapper.Map<SesionesXUsuario>(objLoginSession);
            var resutlSave = _interlControlEntitie.SesionesXUsuario.Add(objSession);
            _interlControlEntitie.SaveChanges();

            var resutl = Mapper.Map<LoginDto>(resutlSave);

            return Mapper.Map<LoginReturnDto>(resutl);

        }

        public bool CerrarSesionUsuario(LoginDto objLogin)
        {
            var objSesion = _interlControlEntitie.SesionesXUsuario.Where(c => 
            c.IdUsuario == objLogin.IdUsuario && c.IdSesionUsuario == objLogin.IdSesionUsuario).FirstOrDefault();


            if (objSesion != null)
            {
                var objSession = Mapper.Map<SesionesXUsuario>(objSesion);
                var resutlSave = _interlControlEntitie.SesionesXUsuario.Remove(objSession);
                _interlControlEntitie.SaveChanges(); 
            }
            return true;
        }
 

        public bool ValidarSessionUsuario(ObjetoSesion sessionUsuario)
        {
            var objUsuario = _interlControlEntitie.tbl_Usuarios.Where(c => c.Email.Equals(sessionUsuario.Email) &&
                c.Passwords.Equals(sessionUsuario.password)).FirstOrDefault();

            var objSesion = _interlControlEntitie.SesionesXUsuario.Where(c =>
                 c.IdUsuario == objUsuario.IdUsuario).FirstOrDefault();

            if (objSesion == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
