using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GlassCoreAPI.DTOs;
using GlassCoreAPI.Models;

namespace GlassCoreAPI.Controllers
{
    public class EstudiantesController : ApiController
    {
        private GlassCoreEntities db = new GlassCoreEntities();

        // GET: api/Estudiantes
        [HttpGet]
        public IQueryable<RankingEstudianteDTO> GetEstudiantesRanking()
        {
            // Realiza una unión entre las tablas Estudiante y Carrera
            var query = from estudiante in db.Estudiante
                        join carrera in db.Carrera on estudiante.Id_Carrera equals carrera.Id_Carrera
                        join usuario in db.Usuario on estudiante.Id_Usuario equals usuario.Id_Usuario
                        orderby estudiante.Indice_General descending // Ordena por Indice_General de mayor a menor
                        select new RankingEstudianteDTO
                        {
                            
                           
                            Nombre = usuario.Nombre_Usuario,
                            Apellido = usuario.Apellido_Usuario,
                            Indice = estudiante.Indice_General,
                           
                            Carrera = carrera.Nombre_Carrera, // Agrega el Nombre_Carrera
                           
                            Trimestre = estudiante.Trimestre
                        };



            return query;
        }



        // GET: api/Estudiantes/5
        [ResponseType(typeof(Estudiante))]
        public IHttpActionResult GetEstudiante(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(estudiante);
        }

        // PUT: api/Estudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstudiante(int id, Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.Id_Estudiante)
            {
                return BadRequest();
            }

            db.Entry(estudiante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Estudiantes
        [ResponseType(typeof(Estudiante))]
        [HttpPost]
        public IHttpActionResult PostEstudiante(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estudiante.Add(estudiante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estudiante.Id_Estudiante }, estudiante);
        }

        // DELETE: api/Estudiantes/5
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstudianteExists(int id)
        {
            return db.Estudiante.Count(e => e.Id_Estudiante == id) > 0;
        }
    }
}