using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWebApi.Models
{
    public class Alumnos
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
    }
}