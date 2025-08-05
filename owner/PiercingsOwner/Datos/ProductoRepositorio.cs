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
            AbrirConexion();
            List<Producto> productos = new List<Producto>();
            try
            {
                string query = "SELECT * FROM Productos WHERE CategoriaId IN (@CategoriaIds)";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@CategoriaIds", string.Join(", ", categorias.Select(c => Producto.ParseCategoriaToId(c))));
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        (
                            reader.GetInt32("Id"),
                            Producto.ParseCategoriaToId((Categoria)reader.GetInt32("CategoriaId")),
                            reader.GetInt32("Inventario")
                        )
                        {
                            Nombre = reader.GetString("Nombre"),
                            Color = reader.GetString("Color")
                        };
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar productos por categoría: {ex.Message}");
            }
            finally
            {
                CerrarConexion();
            }
            return productos;
        }

        public Producto BuscarPorId(int id)
        {
            AbrirConexion();
            Producto producto = null!;
            try
            {
                string query = "SELECT * FROM Productos WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        (
                            reader.GetInt32("Id"),
                            Producto.ParseCategoriaToId((Categoria)reader.GetInt32("CategoriaId")),
                            reader.GetInt32("Inventario")
                        )
                        {
                            Nombre = reader.GetString("Nombre"),
                            Color = reader.GetString("Color")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar producto por ID: {ex.Message}");
                throw new InvalidOperationException("Error al buscar el producto por ID.");
            }
            finally
            {
                CerrarConexion();
            }
            if (producto == null)
            {
                throw new InvalidOperationException("Producto no encontrado.");
            }
            return producto;
        }

        public List<Producto> BuscarTodos()
        {
            AbrirConexion();
            List<Producto> productos = new List<Producto>();
            try
            {
                string query = "SELECT * FROM Productos";
                MySqlCommand command = new MySqlCommand(query, _connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto
                        (
                            reader.GetInt32("Id"),
                            Producto.ParseCategoriaToId((Categoria)reader.GetInt32("CategoriaId")),
                            reader.GetInt32("Inventario")
                        )
                        {
                            Nombre = reader.GetString("Nombre"),
                            Color = reader.GetString("Color")
                        };
                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar todos los productos: {ex.Message}");
            }
            finally
            {
                CerrarConexion();
            }
            return productos;
        }

        public bool Deshabilitar(int id)
        {
            var resultado = false;
            try
            {
                AbrirConexion();
                string query = "UPDATE Productos SET Estado = 0 WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);
                int rowsAffected = command.ExecuteNonQuery();
                resultado = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deshabilitar producto: {ex.Message}");
            }
            finally
            {
                CerrarConexion();
            }
            return resultado;
        }

        public Producto Guardar(Producto producto)
        {
            try
            {
                AbrirConexion();
                string query = "INSERT INTO Productos (Nombre, CategoriaId, Color, Inventario) VALUES (@Nombre, @CategoriaId, @Color, @Inventario)";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@CategoriaId", (int)producto.Categoria);
                command.Parameters.AddWithValue("@Color", producto.Color);
                command.Parameters.AddWithValue("@Inventario", producto.Inventario);
                command.ExecuteNonQuery();

                producto.Id = (int)command.LastInsertedId;
                return producto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar producto: {ex.Message}");
                throw new InvalidOperationException("Error al guardar el producto.");
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
