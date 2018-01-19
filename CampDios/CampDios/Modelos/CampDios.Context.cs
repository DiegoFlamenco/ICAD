﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CampDiosEntities : DbContext
    {
        public CampDiosEntities()
            : base("name=CampDiosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Capacitaciones> Capacitaciones { get; set; }
        public virtual DbSet<Comunidad> Comunidad { get; set; }
        public virtual DbSet<DetalleFamilia> DetalleFamilia { get; set; }
        public virtual DbSet<DetalleGrupo> DetalleGrupo { get; set; }
        public virtual DbSet<Dias> Dias { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<Finanzas> Finanzas { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<HistoriaEspiritual> HistoriaEspiritual { get; set; }
        public virtual DbSet<Iglesia> Iglesia { get; set; }
        public virtual DbSet<LiderazgoCorporativo> LiderazgoCorporativo { get; set; }
        public virtual DbSet<Miembros> Miembros { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Opciones> Opciones { get; set; }
        public virtual DbSet<Parentescos> Parentescos { get; set; }
        public virtual DbSet<Pastores> Pastores { get; set; }
        public virtual DbSet<Profesion> Profesion { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesPastor> RolesPastor { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<Tipo_Grupo> Tipo_Grupo { get; set; }
        public virtual DbSet<TipoOfrenda> TipoOfrenda { get; set; }
        public virtual DbSet<TipoReunion> TipoReunion { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Usuarios_Opciones> Usuarios_Opciones { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
    
        public virtual ObjectResult<GetUserAction_Result> GetUserAction(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserAction_Result>("GetUserAction", userNameParameter);
        }
    
        public virtual ObjectResult<seleccionar_aprendiz_Result> seleccionar_aprendiz()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_aprendiz_Result>("seleccionar_aprendiz");
        }
    
        public virtual ObjectResult<seleccionar_lider_Result> seleccionar_lider()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_lider_Result>("seleccionar_lider");
        }
    
        public virtual ObjectResult<seleccionar_miembro_Result> seleccionar_miembro()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_miembro_Result>("seleccionar_miembro");
        }
    
        public virtual ObjectResult<seleccionar_miembro_nombreCompleto_Result> seleccionar_miembro_nombreCompleto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_miembro_nombreCompleto_Result>("seleccionar_miembro_nombreCompleto");
        }
    
        public virtual ObjectResult<seleccionar_pastor_general_Result> seleccionar_pastor_general()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_pastor_general_Result>("seleccionar_pastor_general");
        }
    
        public virtual ObjectResult<seleccionar_pastor_zona_Result> seleccionar_pastor_zona()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_pastor_zona_Result>("seleccionar_pastor_zona");
        }
    
        public virtual ObjectResult<seleccionar_supervisor_zona_Result> seleccionar_supervisor_zona()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<seleccionar_supervisor_zona_Result>("seleccionar_supervisor_zona");
        }
    }
}
