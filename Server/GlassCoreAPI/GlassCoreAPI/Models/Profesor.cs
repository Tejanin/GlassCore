//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlassCoreAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesor()
        {
            this.Horario_Estudiante_Reporte = new HashSet<Horario_Estudiante_Reporte>();
            this.Horario_Profesor = new HashSet<Horario_Profesor>();
            this.Profesor_Soporte = new HashSet<Profesor_Soporte>();
        }
    
        public int Id_Profesor { get; set; }
        public Nullable<int> Id_Usuario { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario_Estudiante_Reporte> Horario_Estudiante_Reporte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario_Profesor> Horario_Profesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesor_Soporte> Profesor_Soporte { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}