namespace MVC.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class T_Alumno_Curso
    {
        public int id { get; set; }

        public int idAlumno { get; set; }

        public int idCurso { get; set; }

        [Required(ErrorMessage ="DEBE INGRESAR UNA NOTA")]
        [Range(0,100,ErrorMessage ="DEBE INGRESAR UNA NOTA DE ENTRE 0 A 20")]
        public int Nota { get; set; }

        public virtual T_Alumno T_Alumno { get; set; }

        public virtual T_Curso T_Curso { get; set; }


        public ResponseModel Guardar(T_Alumno_Curso alumnoCurso)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new TestContext())
                {

                    db.Entry<T_Alumno_Curso>(alumnoCurso).State = EntityState.Added;
                    //db.Set<T_Alumno>().Add(alumno);
                    
                    rm.SetResponse(true);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }


        public List<T_Alumno_Curso> Listar(int idAlumno)
        {
            var alumnocursos = new List<T_Alumno_Curso>();

            using (var db = new TestContext())
            {
                alumnocursos = db.T_Alumno_Curso.Include("T_Curso")
                    .Where(x=>x.idAlumno == idAlumno)
                    .ToList();
            }

            return alumnocursos;
        }
    }//class
}
