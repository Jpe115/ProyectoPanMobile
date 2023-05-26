using ProyectoPanMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPanMobile.Data
{
    public class PanRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pan.db");

        public PanRepository()
        {
            _database = new SQLiteAsyncConnection(DbPath);
            _database.CreateTableAsync<Panes>();
            _database.CreateTableAsync<Usuarios>();
            _database.CreateTableAsync<PanesCarrito>();
        }

        public async Task<List<Panes>> PanesLista() {
            return await _database.Table<Panes>().ToListAsync();
        }

        public async Task<List<PanesCarrito>> Carrito()
        {
            return await _database.Table<PanesCarrito>().ToListAsync();
        }

        public async Task AgregarAlCarrito(Panes pan, int cant)
        {
            PanesCarrito panz = new PanesCarrito() { PanID = pan.PanID, NombrePan = pan.NombrePan,
            Descripcion = pan.Descripcion, Imagen = pan.Imagen, Precio = pan.Precio, Cantidad = cant};
            await _database.InsertAsync(panz);
        }
    }
}
