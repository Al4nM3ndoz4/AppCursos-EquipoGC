using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad1_P2_CRUD.Models
{
    public class Users
    { 
        [PrimaryKey, AutoIncrement]

        public int UserId { get; set; }

        [MaxLength(30)]

        public string Email { get; set; }

        [MaxLength(15)]

        public string Emailpassword { get; set; }

        [MaxLength(30)]
        public string NombreCompleto { get; set; }

        public int Edad { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
