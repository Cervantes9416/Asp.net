using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entidades.Controllers
{
    public class AlumnoController
    {
        public List<T_Alumno> GetAll()

        {
            var listado = new List<T_Alumno>();

            using (var db = new DataContext())
            {
                listado = db.T_Alumno.Include("T_Alumno_Curso")
                    .Include("T_Alumno_Curso.T_Curso")
                    .ToList();   
            }

            return listado;
        }//GetAll

        public void Save(T_Alumno model)
        {
            using (var db =new DataContext())
            {
                db.Entry<T_Alumno>(model).State = EntityState.Added;
                //db.Set<T_Alumno>().Add(alumno);
                db.SaveChanges();
            }
        }//Save

        public T_Alumno Get(int id)
        {
            var alumno = new T_Alumno();

            using(var db = new DataContext())
            {
                alumno = db.T_Alumno.Where(x => x.idAlumno == id).SingleOrDefault();
            }//using

            return alumno;
        }//Get

    }
}
