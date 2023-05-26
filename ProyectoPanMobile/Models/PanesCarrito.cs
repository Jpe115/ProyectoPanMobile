using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.Models
{
    public class PanesCarrito
    {
        [PrimaryKey, AutoIncrement]
        public int PanID { get; set; }
        public string NombrePan { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Imagen { get; set; }
        public int Cantidad { get; set; }
    }
}
