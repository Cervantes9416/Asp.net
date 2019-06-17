namespace Test.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Adjunto
    {
        public int id { get; set; }

        public int? IdAlumno { get; set; }

        [Required]
        [StringLength(100)]
        public string Archivo { get; set; }

        public virtual T_Alumno T_Alumno { get; set; }
    }
}
