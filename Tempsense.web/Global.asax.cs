
namespace Tempsense.web
{
    using AutoMapper;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Tempsense.Entities;
    using Tempsense.Entities.Dtos.Dtos.Bitacoras;
    using Tempsense.Entities.Dtos.Dtos.Dispositivos;
    using Tempsense.Entities.Dtos.Dtos.Empresas;
    using Tempsense.Entities.Dtos.Dtos.Login;
    using Tempsense.Entities.Dtos.Dtos.Maestros;
    using Tempsense.Entities.Dtos.Dtos.Perfiles;
    using Tempsense.Entities.Dtos.Dtos.Sedes;
    using Tempsense.Entities.Dtos.Dtos.Umbrales;
    using Tempsense.Entities.Dtos.Dtos.Usuarios;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UsuariosDto, tbl_Usuarios>().ForMember(g => g.tbl_Empresas, opt => opt.Ignore())
                                                          .ForMember(g => g.tbl_Perfiles, opt => opt.Ignore())
                                                          .ForMember(g => g.tbl_UsuariosXSedes, opt => opt.Ignore());
                cfg.CreateMap<tbl_Usuarios, UsuariosDto>();

                cfg.CreateMap<EmpresasDto, tbl_Empresas>().ForMember(g => g.tbl_Sedes, opt => opt.Ignore())
                                                         .ForMember(g => g.tbl_ModulosXPerfil, opt => opt.Ignore())
                                                         .ForMember(g => g.tbl_Usuarios, opt => opt.Ignore());
                cfg.CreateMap<tbl_Empresas, EmpresasDto>();

                cfg.CreateMap<PerfilesDto, tbl_Perfiles>().ForMember(g => g.tbl_ModulosXPerfil, opt => opt.Ignore())
                                                          .ForMember(g => g.tbl_Usuarios, opt => opt.Ignore());
                cfg.CreateMap<tbl_Perfiles, PerfilesDto>();

                cfg.CreateMap<LoginDto, SesionesXUsuario>();
                cfg.CreateMap<SesionesXUsuario, LoginDto>();

                cfg.CreateMap<LoginDto, LoginReturnDto>().ForMember(g => g.Mensaje, opt => opt.Ignore());
                cfg.CreateMap<LoginReturnDto, LoginDto>();

                cfg.CreateMap<SedesDto, tbl_Sedes>().ForMember(g => g.tbl_Dispositivos, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_Empresas, opt => opt.Ignore());
                cfg.CreateMap<tbl_Sedes, SedesDto>();


                cfg.CreateMap<DispositivosDto, tbl_Dispositivos>().ForMember(g => g.tbl_Bitacoras, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_Bitacoras1, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_Sedes, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_TipoMedidas, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_Umbrales, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_UltimasMedidas, opt => opt.Ignore());
                cfg.CreateMap<tbl_Bitacoras, DispositivosDto>();


                cfg.CreateMap<BitacorasDto, tbl_Bitacoras>().ForMember(g => g.tbl_Dispositivos, opt => opt.Ignore())
                                                     .ForMember(g => g.tbl_Dispositivos1, opt => opt.Ignore());
                cfg.CreateMap<tbl_Bitacoras, BitacorasDto>();
                

                cfg.CreateMap<UmbralesDto, tbl_Umbrales>().ForMember(g => g.tbl_Dispositivos, opt => opt.Ignore());
                cfg.CreateMap<tbl_Umbrales, UmbralesDto>();

                cfg.CreateMap<TipoMedidasDto, tbl_TipoMedidas>().ForMember(g => g.tbl_Dispositivos, opt => opt.Ignore());
                cfg.CreateMap<tbl_TipoMedidas, TipoMedidasDto>();

                cfg.CreateMap<UsuariosXSedeDto, tbl_UsuariosXSedes>().ForMember(g => g.tbl_Sedes, opt => opt.Ignore())
                                                                     .ForMember(g => g.tbl_Usuarios, opt => opt.Ignore());
                cfg.CreateMap<tbl_UsuariosXSedes, UsuariosXSedeDto>();

                

            });
        }

    }
}
