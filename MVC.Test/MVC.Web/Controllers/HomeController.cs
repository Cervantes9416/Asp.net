using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Entidades;
using MVC.Controllers;

namespace MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        //Alumno alumno = new Alumno();
        Alumno_Controller alumno = new Alumno_Controller();
        T_Alumno_Curso alumno_curso = new T_Alumno_Curso();
        T_Curso curso = new T_Curso();


        //localhost/Home/Index
        public ActionResult Index()
        {
            return View(alumno.listar());
            //ViewBag.Alumnos = alumno.Listar();
            //return View(alumno.Listar());
        }

        /*public ActionResult Ver(int id=0)
        {
            ViewBag.Id = id;
            return View(new Alumno());
        }*/

        public ActionResult Ver(int id)
        {
            //return View(alumno.Obtener());
            return View(alumno.Obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {
            return View(id == 0 ? alumno.NuevoAlumno() : alumno.Obtener(id));
        }

        //public ActionResult Guardar(T_Alumno alumno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.alumno.Guardar(alumno);
        //        return Redirect("~/Home/Index");
        //    }
        //    else
        //    {
        //        return View("~/views/home/crud.cshtml",alumno);
        //    }

        //}

        public JsonResult Guardar(T_Alumno alumno)
        {
            var rm =new  ResponseModel();

            if (ModelState.IsValid)
            {
                rm = this.alumno.Guardar(alumno);
                if (rm.response)
                {
                    rm.href = Url.Content("~/Home");
                }
            }

            return Json(rm);
        }//Guardar()

        public ActionResult Eliminar(int id)
        {
            alumno.Eliminar(id);
            return Redirect("~/Home/Index");
        }

        public PartialViewResult Cursos(int idAlumno)
        {
            ViewBag.CursosElegidos = alumno_curso.Listar(idAlumno);

            ViewBag.cursos = curso.Listar(idAlumno);
            alumno_curso.id = idAlumno;
            return PartialView(alumno_curso);
        }

        public JsonResult GuardarCurso(T_Alumno_Curso model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                rm = alumno_curso.Guardar(model);
                if (rm.response)
                {
                    //rm.href = Url.Content("~/Home");
                    rm.function = "cargarCursos()";
                }
            }

            return Json(rm);
        }
       
    }
}