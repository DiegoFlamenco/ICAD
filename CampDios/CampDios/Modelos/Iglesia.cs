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
    
    public partial class Iglesia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Iglesia()
        {
            this.HistoriaEspiritual = new HashSet<HistoriaEspiritual>();
            this.Miembros1 = new HashSet<Miembros>();
            this.Pastores1 = new HashSet<Pastores>();
            this.Zona = new HashSet<Zona>();
        }
    
        public int IdIglesia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Email { get; set; }
        public Nullable<int> IdMiembro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriaEspiritual> HistoriaEspiritual { get; set; }
        public virtual Miembros Miembros { get; set; }
        public virtual Pastores Pastores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembros> Miembros1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pastores> Pastores1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zona> Zona { get; set; }
    }
}
