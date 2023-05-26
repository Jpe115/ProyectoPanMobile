using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.Models
{
    public class Usuarios
    {
        [PrimaryKey,AutoIncrement]
        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Foto { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
