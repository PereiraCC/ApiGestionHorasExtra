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
    
    public partial class FORMULARIO_SOLICITUD_TAREAS
    {
        public int idFormularioSolicitud { get; set; }
        public int idPersona { get; set; }
        public string Motivo { get; set; }
        public System.DateTime Entrada { get; set; }
        public System.DateTime Salida { get; set; }
        public int TotalHoras { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    
        public virtual PERSONAS PERSONAS { get; set; }
    }
}
