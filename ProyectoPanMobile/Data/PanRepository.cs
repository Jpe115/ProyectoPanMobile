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
        }

        public async Task<List<Panes>> PanesLista() {
            return await _database.Table<Panes>().ToListAsync();
        }
    }
}
