using PiercingsOwner.Negocio.ModeloDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PiercingsOwner.Datos
{
    internal class ProductoRepositorio : IProductoRepositorio
    {
        private readonly string _connectionString;
        private MySqlConnection _connection;
        public ProductoRepositorio()
        {
            _connectionString = "server=localhost;port=3306;database=PiercingsDB;uid=sa;password=123456;";
            _connection = new MySqlConnection(_connectionString);
            this.ProbarConexion();
        }
        private void AbrirConexion()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        private void CerrarConexion()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        private bool ProbarConexion()
        {
            try
            {
                AbrirConexion();
                CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Producto> BuscarPorCategoria(List<Categoria> categorias)
        {
            throw new NotImplementedException();
        }

        public Producto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Deshabilitar(int id)
        {
            throw new NotImplementedException();
        }

        public Producto Guardar(Producto entidad)
        {
            throw new NotImplementedException();
        }
    }
}
