using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampDios.Modelos
{
    public class Miembros_Edad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Miembros_Edad()
        {
            this.Comunidad = new HashSet<Comunidad>();
            this.DetalleFamilia = new HashSet<DetalleFamilia>();
            this.DetalleFamilia1 = new HashSet<DetalleFamilia>();
            this.DetalleGrupo = new HashSet<DetalleGrupo>();
            this.Finanzas = new HashSet<Finanzas>();
            this.HistoriaEspiritual = new HashSet<HistoriaEspiritual>();
            this.Iglesia = new HashSet<Iglesia>();
            this.Miembros1 = new HashSet<Miembros>();
            this.Zona = new HashSet<Zona>();
        }

        public int IdMiembro { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public System.DateTime FechaNacimiento { get; set; } 
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Cel { get; set; }
        public int Sexo { get; set; } // Id del sexo :v
        public string SexoDescripcion { get; set; }
        public int IdEstadoCivil { get; set; } // id estado civil
        public string NombreEstadoC { get; set; } // nombre de estado civil
        public Nullable<int> IdProfesion { get; set; }//id profesion
        public string NombreProfesion { get; set; } // nombre de profesion
        public Nullable<int> IdCapacitacion { get; set; } // Id de la capacitacion
        public string NombreCapacitacion { get; set; } // nombre de capacitacion
        public Nullable<int> IdRol { get; set; }//id rol
        public string NombreRol{ get; set; } // nombre del rol
        public Nullable<int> IdHMayor { get; set; } //id del hermano mayor
        public string NombreHermanoM { get; set; } // nombre del hermano mayor
        public Nullable<int> IdCorporativo { get; set; } // id corporativo
        public string NombreCorporativo { get; set; } // nombre de capacitacion

        public virtual Capacitaciones Capacitaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comunidad> Comunidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFamilia> DetalleFamilia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFamilia> DetalleFamilia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleGrupo> DetalleGrupo { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finanzas> Finanzas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoriaEspiritual> HistoriaEspiritual { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iglesia> Iglesia { get; set; }
        public virtual LiderazgoCorporativo LiderazgoCorporativo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembros> Miembros1 { get; set; }
        public virtual Miembros Miembros2 { get; set; }
        public virtual Profesion Profesion { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual Sexo Sexo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zona> Zona { get; set; }
    }
}