//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CampDios.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleGrupo
    {
        public int IdDetalleGrupo { get; set; }
        public int IdGrupo { get; set; }
        public int IdMiembro { get; set; }
    
        public virtual Grupo Grupo { get; set; }
        public virtual Miembros Miembros { get; set; }
        public virtual Pastores Pastores { get; set; }
    }
}
