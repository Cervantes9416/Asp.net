using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Entidades;
using Test.Entidades.Controllers;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        AlumnoController alumno_controlador = new AlumnoController();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Get(int id)
        {
            var model = alumno_controlador.Get(id);
            return PartialView(model);
        }

        public PartialViewResult GetAll()
        {
            var listado = alumno_controlador.GetAll();
            return PartialView(listado);
        }

        public PartialViewResult Create()
        {
            return PartialView(new T_Alumno());
        }

        [HttpPost]
        public ActionResult Create(T_Alumno model)
        {
            alumno_controlador.Save(model);
            return Redirect("~/Home/Index");
        }
    }
}