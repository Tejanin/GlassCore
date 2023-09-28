﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GlassCoreEntities : DbContext
    {
        public GlassCoreEntities()
            : base("name=GlassCoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Asignatura> Asignatura { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Ciclo> Ciclo { get; set; }
        public virtual DbSet<Codigo_Asignatura> Codigo_Asignatura { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Estudiante_Soporte> Estudiante_Soporte { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Pensum> Pensum { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Profesor_Soporte> Profesor_Soporte { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Tarea> Tarea { get; set; }
        public virtual DbSet<Titulo> Titulo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    
        public virtual ObjectResult<ppFiltrarUsuarios_Result> ppFiltrarUsuarios(string ordenamiento, string rol, string estado)
        {
            var ordenamientoParameter = ordenamiento != null ?
                new ObjectParameter("Ordenamiento", ordenamiento) :
                new ObjectParameter("Ordenamiento", typeof(string));
    
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ppFiltrarUsuarios_Result>("ppFiltrarUsuarios", ordenamientoParameter, rolParameter, estadoParameter);
        }
    
        public virtual int ppInsertarUsuario(string rol, string nombre_Usuario, string apellido_Usuario, string imagen, Nullable<long> userName, string password, string email, string estado)
        {
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            var nombre_UsuarioParameter = nombre_Usuario != null ?
                new ObjectParameter("Nombre_Usuario", nombre_Usuario) :
                new ObjectParameter("Nombre_Usuario", typeof(string));
    
            var apellido_UsuarioParameter = apellido_Usuario != null ?
                new ObjectParameter("Apellido_Usuario", apellido_Usuario) :
                new ObjectParameter("Apellido_Usuario", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var userNameParameter = userName.HasValue ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(long));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ppInsertarUsuario", rolParameter, nombre_UsuarioParameter, apellido_UsuarioParameter, imagenParameter, userNameParameter, passwordParameter, emailParameter, estadoParameter);
        }
    
        public virtual int ppLogin(Nullable<long> userName, string password, ObjectParameter tipoUsuario)
        {
            var userNameParameter = userName.HasValue ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(long));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ppLogin", userNameParameter, passwordParameter, tipoUsuario);
        }
    
        public virtual int ppModificarUsuario(Nullable<int> id_Usuario, string nombre_Usuario, string apellido_Usuario, string email, string imagen, string estado, Nullable<long> userName, string password, string rol)
        {
            var id_UsuarioParameter = id_Usuario.HasValue ?
                new ObjectParameter("Id_Usuario", id_Usuario) :
                new ObjectParameter("Id_Usuario", typeof(int));
    
            var nombre_UsuarioParameter = nombre_Usuario != null ?
                new ObjectParameter("Nombre_Usuario", nombre_Usuario) :
                new ObjectParameter("Nombre_Usuario", typeof(string));
    
            var apellido_UsuarioParameter = apellido_Usuario != null ?
                new ObjectParameter("Apellido_Usuario", apellido_Usuario) :
                new ObjectParameter("Apellido_Usuario", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            var userNameParameter = userName.HasValue ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(long));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ppModificarUsuario", id_UsuarioParameter, nombre_UsuarioParameter, apellido_UsuarioParameter, emailParameter, imagenParameter, estadoParameter, userNameParameter, passwordParameter, rolParameter);
        }
    }
}
