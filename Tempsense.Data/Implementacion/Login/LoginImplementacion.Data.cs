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
            objLoginSession.IdSede = objUsuario.IdSede;
            objLoginSession.IdPerfil = objUsuario.IdPerfil;
            
            var objSession = Mapper.Map<SesionesXUsuario>(objLoginSession);
            var resutlSave = _interlControlEntitie.SesionesXUsuario.Add(objSession);
            _interlControlEntitie.SaveChanges();

            objLoginSession.IdSesionUsuario = resutlSave.IdSesionUsuario;

            var resutl = Mapper.Map<LoginDto>(objLoginSession);

            var returnData = Mapper.Map<LoginReturnDto>(resutl);

            return returnData;

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
 

        public bool ValidarSessionUsuario(ValidatorSesionDto validator)
        {
           
            var objSesion = _interlControlEntitie.SesionesXUsuario.Where(c =>
                 c.IdUsuario == validator.IdUsuario && c.IdSesionUsuario == validator.IdSesionUsuario).FirstOrDefault();

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
