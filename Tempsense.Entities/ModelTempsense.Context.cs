﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tempsense.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IntelControlEntities : DbContext
    {
        public IntelControlEntities()
            : base("name=IntelControlEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Perfiles> tbl_Perfiles { get; set; }
        public virtual DbSet<tbl_Dispositivos> tbl_Dispositivos { get; set; }
        public virtual DbSet<tbl_Sedes> tbl_Sedes { get; set; }
        public virtual DbSet<tbl_TipoMedidas> tbl_TipoMedidas { get; set; }
        public virtual DbSet<tbl_Modulos> tbl_Modulos { get; set; }
        public virtual DbSet<tbl_ModulosXPerfil> tbl_ModulosXPerfil { get; set; }
        public virtual DbSet<tbl_Empresas> tbl_Empresas { get; set; }
        public virtual DbSet<tbl_Usuarios> tbl_Usuarios { get; set; }
        public virtual DbSet<SesionesXUsuario> SesionesXUsuario { get; set; }
    }
}
