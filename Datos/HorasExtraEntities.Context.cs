﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HorasExtraEntities : DbContext
    {
        public HorasExtraEntities()
            : base("name=HorasExtraEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DEPARTAMENTOS> DEPARTAMENTOS { get; set; }
        public virtual DbSet<EVIDENCIAS> EVIDENCIAS { get; set; }
        public virtual DbSet<FORMULARIOS_AVALADOS> FORMULARIOS_AVALADOS { get; set; }
        public virtual DbSet<FORMULARIOS_PAGO> FORMULARIOS_PAGO { get; set; }
        public virtual DbSet<FORMULARIOS_TIEMPO> FORMULARIOS_TIEMPO { get; set; }
        public virtual DbSet<JORNADAS> JORNADAS { get; set; }
        public virtual DbSet<PAGOS> PAGOS { get; set; }
        public virtual DbSet<PERSONAS> PERSONAS { get; set; }
        public virtual DbSet<SOLICITUD_TAREAS> SOLICITUD_TAREAS { get; set; }
        public virtual DbSet<TIPOSPAGO> TIPOSPAGO { get; set; }
        public virtual DbSet<TareaPersona> TareaPersona { get; set; }
        public virtual DbSet<FormulariosSolcitudPersona> FormulariosSolcitudPersona { get; set; }
        public virtual DbSet<DocumentosEvidencias> DocumentosEvidencias { get; set; }
        public virtual DbSet<ObtenerFormularioAvaladoTiempo> ObtenerFormularioAvaladoTiempo { get; set; }
    }
}
