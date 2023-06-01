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
        SQLiteAsyncConnection _database;

        public static string DbPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pan.db");

        public PanRepository()
        {
            _database = new SQLiteAsyncConnection(DbPath);
            _database.CreateTableAsync<Panes>();
            _database.CreateTableAsync<Usuarios>();
            _database.CreateTableAsync<PanesCarrito>();
        }
        #region
        public async Task<List<Panes>> PanesLista() {
            return await _database.Table<Panes>().ToListAsync();
        }

        public async Task<List<PanesCarrito>> Carrito()
        {
            return await _database.Table<PanesCarrito>().ToListAsync();
        }

        public async Task AgregarAlCarrito(PanesCarrito pan, int cant)
        {
            pan.Cantidad = cant;
            var lista = await Carrito();
            if (lista.Count == 0)
            {
                await _database.InsertAsync(pan);
            }
            else
            {
                bool panEncontrado = false;
                foreach (var pana in lista)
                {
                    if (pan.NombrePan == pana.NombrePan)
                    {
                        pana.Cantidad = cant;
                        await _database.UpdateAsync(pana);
                        panEncontrado = true;
                        break;
                    }
                }
                if (!panEncontrado)
                {
                    await _database.InsertAsync(pan);
                }
            }
        }

        public async Task ReiniciarCarrito()
        {
            await _database.DeleteAllAsync<PanesCarrito>();
        }

        public async Task ActualizarImagenes(string[] imgs)
        {
            var lista = await PanesLista();
            for (int i = 0; i < imgs.Length; i++)
            {
                lista[i].Imagen = imgs[i];
                await _database.UpdateAsync(lista[i]);
            }
        }
        public async Task ImgsACarrito(string[] imgs)
        {
            var lista = await Carrito();
            foreach (var pan in lista)
            {
                switch (pan.PanID)
                {
                    case 1:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 2:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 3: pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 4:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 5:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 6:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 7:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                    case 8:
                        pan.Imagen = imgs[pan.PanID - 1];
                        break;
                }
                await _database.UpdateAsync(pan);
            }
        }
        #endregion

        public async Task RegistrarUsuario(string nombre, string contra)
        {
            Usuarios usuario = new Usuarios()
            {
                NombreUsuario = nombre,
                Contraseña = contra,
                Email = "",
                Telefono = 0,
                Direccion = "",
                Foto = ""
            };
            await _database.InsertAsync(usuario);
        }

        public async Task ModificarUsuario(Usuarios usuario)
        {
            await _database.UpdateAsync(usuario);
        }

        public async Task<List<Usuarios>> ListarUsuarios()
        {
            var listaUsuarios = await _database.Table<Usuarios>().ToListAsync();
            return listaUsuarios;
        }

        public async Task<bool> ExisteUsuario(string cuenta, string contra)
        {
            var listaUsuarios = await ListarUsuarios();
            bool existeUsuario = false;
            foreach(Usuarios usuario in listaUsuarios)
            {
                if(usuario.NombreUsuario == cuenta && usuario.Contraseña == contra)
                {
                    existeUsuario = true;
                    break;
                }
            }
            return existeUsuario;
        }

        public async Task<Usuarios> CualUsuario(string nombre)
        {
            var listaUsuarios = await ListarUsuarios();
            Usuarios elElegido = new Usuarios();
            foreach (Usuarios usuario in listaUsuarios)
            {
                if(usuario.NombreUsuario == nombre)
                {
                    elElegido = usuario;
                }
            }
            return elElegido;
        }
        
        public async Task<bool> isUsuarioRepetido(string nombre)
        {
            var listaUsuarios = await ListarUsuarios();
            bool isRepetido = false;
            foreach (Usuarios usuario in listaUsuarios)
            {
                if (usuario.NombreUsuario == nombre)
                {
                    isRepetido = true;
                }
            }
            return isRepetido;
        }
    }
}
