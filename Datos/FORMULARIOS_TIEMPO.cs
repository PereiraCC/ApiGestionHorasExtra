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
    
    public partial class FORMULARIOS_TIEMPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FORMULARIOS_TIEMPO()
        {
            this.FORMULARIOS_PAGO = new HashSet<FORMULARIOS_PAGO>();
        }
    
        public int idFormularioTiempo { get; set; }
        public int idFormularioAvalado { get; set; }
        public int HorasValidas { get; set; }
        public string QUINCENA { get; set; }
    
        public virtual FORMULARIOS_AVALADOS FORMULARIOS_AVALADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FORMULARIOS_PAGO> FORMULARIOS_PAGO { get; set; }
    }
}