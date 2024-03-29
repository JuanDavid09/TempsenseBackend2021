using System.Web.Mvc;
using Tempsense.Bussines.Implementacion.Bitacora;
using Tempsense.Bussines.Implementacion.Contactenos;
using Tempsense.Bussines.Implementacion.Dispositivos;
using Tempsense.Bussines.Implementacion.Empresas;
using Tempsense.Bussines.Implementacion.Login;
using Tempsense.Bussines.Implementacion.Maestros;
using Tempsense.Bussines.Implementacion.Perfiles;
using Tempsense.Bussines.Implementacion.Sedes;
using Tempsense.Bussines.Implementacion.Umbral;
using Tempsense.Bussines.Implementacion.Usuarios;
using Tempsense.Bussines.Interfaz.Bitacora;
using Tempsense.Bussines.Interfaz.Contactenos;
using Tempsense.Bussines.Interfaz.Dispositivos;
using Tempsense.Bussines.Interfaz.Empresas;
using Tempsense.Bussines.Interfaz.Login;
using Tempsense.Bussines.Interfaz.Maestros;
using Tempsense.Bussines.Interfaz.Perfiles;
using Tempsense.Bussines.Interfaz.Sedes;
using Tempsense.Bussines.Interfaz.Umbral;
using Tempsense.Bussines.Interfaz.Usuarios;
using Tempsense.Data.Implementacion.Bitacora;
using Tempsense.Data.Implementacion.Contactenos;
using Tempsense.Data.Implementacion.Dispositivos;
using Tempsense.Data.Implementacion.Empresas;
using Tempsense.Data.Implementacion.Login;
using Tempsense.Data.Implementacion.Maestros;
using Tempsense.Data.Implementacion.Perfiles;
using Tempsense.Data.Implementacion.Sedes;
using Tempsense.Data.Implementacion.Umbral;
using Tempsense.Data.Implementacion.Usuarios;
using Tempsense.Data.Interfaz.Bitacora;
using Tempsense.Data.Interfaz.Contactenos;
using Tempsense.Data.Interfaz.Dispositivos;
using Tempsense.Data.Interfaz.Empresas;
using Tempsense.Data.Interfaz.Login;
using Tempsense.Data.Interfaz.Maestros;
using Tempsense.Data.Interfaz.Perfiles;
using Tempsense.Data.Interfaz.Sedes;
using Tempsense.Data.Interfaz.Umbral;
using Tempsense.Data.Interfaz.Usuarios;
using Unity;
using Unity.Mvc5;

namespace Tempsense.web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            #region Usuarios
            container.RegisterType<IUsuariosInterfazData, UsuariosImplemetacionData>();
            container.RegisterType<IUsuarioInterfazBussines, UsuariosImplementacionBussines>();
            #endregion

            #region Empresas
            container.RegisterType<IEmpresasInterfazData, EmpresasImplementacionData>();
            container.RegisterType<IEmpresasInterfazBussines, EmpresasImplementacionBussines>();
            #endregion

            #region Perfiles
            container.RegisterType<IPerfilesInterfazData, PerfilesImplmentacionData>();
            container.RegisterType<IPerfilesInterfazBussines, PerfilesImplementacionBussines>();
            #endregion

            #region Login
            container.RegisterType<ILoginInterfazData, LoginImplementacionData>();
            container.RegisterType<ILoginInterfazBussines, LoginImplementacionBussines>();
            #endregion

            #region Sedes
            container.RegisterType<ISedeInterfazData, SedesImplementacionData>();
            container.RegisterType<ISedesInterfazBussines, SedesImplementacionBussines>();
            #endregion

            #region Umbral
            container.RegisterType<IUmbralInterfazData, UmbralImplementacionData>();
            container.RegisterType<IUmbralInterfazBussines, UmbralImplementacionBussines>();
            #endregion

            #region Dispositivos
            container.RegisterType<IDispositivosInterfazData, DispositivosImplementacionData>();
            container.RegisterType<IDispositivosInterfazBussines, DispositivosImplementacionBussines>();
            #endregion

            #region Bitacora
            container.RegisterType<IBitacoraInterfazData, BitacoraImplementacionData>();
            container.RegisterType<IBitacoraInterfazBussines, BitacoraImplementacionBussines>();
            #endregion

            #region Contactenos
            container.RegisterType<IContactenosInterfazData, ContactenosImplementacionData>();
            container.RegisterType<IContactenosInterfazBussines, ContactenosImplementacionBussines>();
            #endregion

            #region Mestros
            container.RegisterType<IMaestrosInterfazData, MaestrosImplementacionData>();
            container.RegisterType<IMaestrosInterfazBussines, MaestrosImplementacionBussines>();
            #endregion


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}