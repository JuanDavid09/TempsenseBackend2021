//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tbl_Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Usuarios()
        {
            this.tbl_UsuariosXSedes = new HashSet<tbl_UsuariosXSedes>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Passwords { get; set; }
        public string Telefono { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPerfil { get; set; }
        public string Email { get; set; }
    
        public virtual tbl_Empresas tbl_Empresas { get; set; }
        public virtual tbl_Perfiles tbl_Perfiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_UsuariosXSedes> tbl_UsuariosXSedes { get; set; }
    }
}
