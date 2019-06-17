namespace MVC.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Curso()
        {
            T_Alumno_Curso = new HashSet<T_Alumno_Curso>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Alumno_Curso> T_Alumno_Curso { get; set; }

        public List<T_Curso> Listar(int alumno_id = 0)
        {
            var cursos = new List<T_Curso>();
            try
            {
                using (var db = new TestContext())
                {
                    cursos = db.T_Curso.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return cursos;    
        }//public
            
    }
}
