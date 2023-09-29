using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlassCoreAPI.DTOs
{
    public class RankingEstudianteDTO
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Carrera { get; set; }

        public int Trimestre { get; set; }

        public decimal Indice { get; set; }

        


    }
}