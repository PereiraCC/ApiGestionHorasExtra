//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class EVIDENCIAS
    {
        public int idEvidencia { get; set; }
        public string RutaDocumento { get; set; }
        public System.DateTime HoraInicial { get; set; }
        public System.DateTime HoraFinal { get; set; }
        public int idSolicitud { get; set; }
        public bool Estado { get; set; }
    
        public virtual SOLICITUD_TAREAS SOLICITUD_TAREAS { get; set; }
    }
}
