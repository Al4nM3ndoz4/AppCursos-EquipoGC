using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Actividad1_P2_CRUD.Models
{
     public class Cursos
    {
        [PrimaryKey, AutoIncrement]

        public int IdCurso { get; set; }

        [MaxLength(50)]

        public string NombreCurso { get; set; }

        [MaxLength(50)]

        public string Tipo { get; set; }

        public int Duracion { get; set; }

    }
}
