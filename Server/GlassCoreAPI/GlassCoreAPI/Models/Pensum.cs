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
    
    public partial class Pensum
    {
        public int Id_Carrera { get; set; }
        public int Id_Asignatura { get; set; }
        public int Año { get; set; }
    
        public virtual Asignatura Asignatura { get; set; }
        public virtual Carrera Carrera { get; set; }
    }
}
