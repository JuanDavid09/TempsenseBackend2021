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
    
    public partial class tbl_UsuariosXSedes
    {
        public int IdUsuariosSedes { get; set; }
        public int IdUsuario { get; set; }
        public int IdSede { get; set; }
    
        public virtual tbl_Sedes tbl_Sedes { get; set; }
        public virtual tbl_Usuarios tbl_Usuarios { get; set; }
    }
}