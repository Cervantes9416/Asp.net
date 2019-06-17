namespace MVC.Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {
        }

        public virtual DbSet<T_Adjunto> T_Adjunto { get; set; }
        public virtual DbSet<T_Alumno> T_Alumno { get; set; }
        public virtual DbSet<T_Alumno_Curso> T_Alumno_Curso { get; set; }
        public virtual DbSet<T_Curso> T_Curso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Adjunto>()
                .Property(e => e.Archivo)
                .IsUnicode(false);

            modelBuilder.Entity<T_Alumno>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<T_Alumno>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<T_Alumno>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<T_Alumno>()
                .HasMany(e => e.T_Alumno_Curso)
                .WithRequired(e => e.T_Alumno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Curso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<T_Curso>()
                .HasMany(e => e.T_Alumno_Curso)
                .WithRequired(e => e.T_Curso)
                .HasForeignKey(e => e.idCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Alumno_Curso>()
                .Property(e => e.Nota);
                
        }
    }
}
