using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    public class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }


        public List<Alumno> Listar()
        {
            var alumnos = new List<Alumno>();

            for (int i = 0; i < 10; i++)
            {   
                alumnos.Add(new Alumno(){
                    id=i,
                    nombre="Alumno "+i
                });
            }

            return alumnos;
        }//LISTAR

        public Alumno Obtener()
        {
            return new Alumno()
            {
                id = 1,
                nombre = "ALUMNO_OBTENER"
            };
        }//OBTENER
    }
}
