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
    
    public partial class Horario_Profesor
    {
        public int Id_Profesor { get; set; }
        public int Id_Asignatura { get; set; }
        public int Seccion { get; set; }
        public System.TimeSpan Hora_Inicio { get; set; }
        public System.TimeSpan Hora_Cierre { get; set; }
        public int Id_Dia { get; set; }
        public int Id_Aula { get; set; }
    
        public virtual Asignatura Asignatura { get; set; }
        public virtual Aula Aula { get; set; }
        public virtual Dias Dias { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}