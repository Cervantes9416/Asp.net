using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Entidades;
using System.Data.Entity;

namespace MVC.Controllers
{
    public class Alumno_Controller
    {
        /// <summary>
        /// Listar el contenido de la Table T_Alumnos
        /// </summary>
        /// <returns></returns>
        public List<T_Alumno> listar()
        {
            var alumnos = new List<T_Alumno>();

            try
            {
                using (var db = new TestContext())
                {
                    alumnos = db.T_Alumno.ToList();
                }
            }
            catch (Exception)
            {

            }

            return alumnos;
        }//Listar()

        /// <summary>
        /// Obtener un registro de la tabla T_Alumno
        /// </summary>
        /// <param name="id">id del Alumno</param>
        /// <returns></returns>
        public T_Alumno Obtener(int id)
        {
            var alumno = new T_Alumno();
            try
            {
                using (var db = new TestContext())
                {
                    alumno = db.T_Alumno.Include("T_Alumno_Curso")
                        .Include("T_Alumno_Curso.T_Curso")
                        .Where(x => x.idAlumno == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return alumno;
        }//Obtener()

        public T_Alumno NuevoAlumno()
        {
            var alumno = new T_Alumno();
            return alumno; 
        }

        //public void Guardar(T_Alumno alumno)
        //{


        //    try
        //    {
        //        using (var db = new TestContext())
        //        {
        //            if (alumno.idAlumno > 0)
        //            {
        //                db.Entry<T_Alumno>(alumno).State = EntityState.Modified;
        //                //var res = db.T_Alumno.Where(x => x.idAlumno == alumno.idAlumno).First();
        //                //res = alumno;
        //            } else
        //            {
        //                db.Entry<T_Alumno>(alumno).State = EntityState.Added;
        //                //db.Set<T_Alumno>().Add(alumno);
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}//Guardar

        public ResponseModel Guardar(T_Alumno alumno)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new TestContext())
                {
                    if (alumno.idAlumno > 0)
                    {
                        db.Entry<T_Alumno>(alumno).State = EntityState.Modified;
                        //var res = db.T_Alumno.Where(x => x.idAlumno == alumno.idAlumno).First();
                        //res = alumno;
                    }
                    else
                    {
                        db.Entry<T_Alumno>(alumno).State = EntityState.Added;
                        //db.Set<T_Alumno>().Add(alumno);
                    }
                    rm.SetResponse(true);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return rm;
        }//Guardar

        public void Eliminar(int id)
        {
            try
            {
                using (var db = new TestContext())
                {
                    var alumno = db.T_Alumno.Where(x => x.idAlumno == id).SingleOrDefault();
                    db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }//Eliminar
       

    }
}
