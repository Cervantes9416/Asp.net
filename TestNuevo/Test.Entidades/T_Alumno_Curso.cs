namespace Test.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Alumno_Curso
    {
        public int id { get; set; }

        public int idAlumno { get; set; }

        public int idCurso { get; set; }

        public int? Nota { get; set; }

        public virtual T_Alumno T_Alumno { get; set; }

        public virtual T_Curso T_Curso { get; set; }
    }
}
