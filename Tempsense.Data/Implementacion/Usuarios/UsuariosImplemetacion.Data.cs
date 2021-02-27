using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempsense.Data.Interfaz.Usuarios;
using Tempsense.Entities;
using Tempsense.Entities.Dtos.Dtos.Empresas;
using Tempsense.Entities.Dtos.Dtos.Perfiles;
using Tempsense.Entities.Dtos.Dtos.Sedes;
using Tempsense.Entities.Dtos.Dtos.Usuarios;

namespace Tempsense.Data.Implementacion.Usuarios
{
    public class UsuariosImplemetacionData : IUsuariosInterfazData
    {
        private IntelControlEntities _interlControlEntitie = new IntelControlEntities();

        public UsuariosDto GuardarUsuario(UsuariosDto userDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Usuarios.Add(Mapper.Map<tbl_Usuarios>(userDto));
            _interlControlEntitie.SaveChanges();
            var result = Mapper.Map<UsuariosDto>(resutlSave);
            this.AddSedesUsuarios(userDto.sedes, result.IdUsuario);
            _interlControlEntitie.SaveChanges();
            return result;
        }

        private bool AddSedesUsuarios(List<SedesDto> sedesDto, int IdUsuario)
        {
            UsuariosXSedeDto obj = new UsuariosXSedeDto();
            List<UsuariosXSedeDto> objList = new List<UsuariosXSedeDto>();
            foreach (var item in sedesDto)
            {
                obj.IdSede = item.IdSede;
                obj.IdUsuario = IdUsuario;
                _interlControlEntitie.tbl_UsuariosXSedes.Add(Mapper.Map<tbl_UsuariosXSedes>(obj));
                _interlControlEntitie.SaveChanges();

            }
            return true;
        }

        public bool EditarUsuario(UsuariosDto userDto)
        {
            var resutlSave = _interlControlEntitie.tbl_Usuarios.Where(c => c.IdUsuario == userDto.IdUsuario).FirstOrDefault();
            var resultSedes = _interlControlEntitie.tbl_UsuariosXSedes.Where(c => c.IdUsuario == userDto.IdUsuario).ToList();
            resutlSave.Nombre = userDto.Nombre;
            resutlSave.Passwords = userDto.Passwords;
            resutlSave.Telefono = userDto.Telefono;
            resutlSave.Email = userDto.Email;
            resutlSave.IdPerfil = userDto.IdPerfil;
            resutlSave.IdEmpresa = userDto.IdEmpresa;
            // edita las sedes el cliente.
            if (resultSedes.Count > 0)
            {
                foreach (var item in resultSedes)
                {
                    _interlControlEntitie.tbl_UsuariosXSedes.Remove(item);
                    _interlControlEntitie.SaveChanges();
                } 
            }

            this.AddSedesUsuarios(userDto.sedes, userDto.IdUsuario);

            _interlControlEntitie.SaveChanges();

            return true;
        }

        public bool EliminarUsuario(int IdUser)
        {
            var resutlSave = _interlControlEntitie.tbl_Usuarios.Where(c => c.IdUsuario == IdUser).FirstOrDefault();
            _interlControlEntitie.tbl_Usuarios.Remove(resutlSave);
            _interlControlEntitie.SaveChanges();
            return true;
        }

        public List<UsuariosStrDto> GetAllUsuarios()
        {
            
            List<UsuariosStrDto> objUserLst = new List<UsuariosStrDto>();
            var resutlSave = _interlControlEntitie.tbl_Usuarios.ToList();
            foreach (var item in resutlSave)
            {
                UsuariosStrDto objUser = new UsuariosStrDto();
                var resulSedes = (from sxu in _interlControlEntitie.tbl_UsuariosXSedes
                                  join s in _interlControlEntitie.tbl_Sedes on sxu.IdSede equals s.IdSede
                                  where sxu.IdUsuario == item.IdUsuario
                                  select new SedesDto
                                  {
                                      IdEmpresa = s.IdEmpresa,
                                      IdSede = s.IdSede,
                                      Nombre = s.Nombre
                                  }).ToList();

                objUser.IdEmpresa = Mapper.Map<EmpresasDto>(_interlControlEntitie.tbl_Empresas.Where(c => c.IdEmpresa == item.IdEmpresa).FirstOrDefault());
                objUser.IdPerfil = Mapper.Map<PerfilesDto>( _interlControlEntitie.tbl_Perfiles.Where(c => c.IdPerfil == item.IdPerfil).FirstOrDefault());
                objUser.IdUsuario = item.IdUsuario;
                objUser.Nombre = item.Nombre;
                objUser.Passwords = item.Passwords;
                objUser.Telefono = item.Telefono;
                objUser.Email = item.Email;
                //if (resulSedes)
                //{
                    objUser.sedes = resulSedes; 
                //}
                objUserLst.Add(objUser);
            }
           
            var resultMapper =  Mapper.Map<List<UsuariosStrDto>>(objUserLst);
            return resultMapper;
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
