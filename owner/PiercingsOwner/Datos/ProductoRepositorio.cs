using PiercingsOwner.Negocio.ModeloDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PiercingsOwner.Datos
{
    /// <summary>
    /// Repositorio para manejar operaciones de productos en la base de datos.
    /// Implementa la interfaz IProductoRepositorio.
    /// </summary>
    public class ProductoRepositorio : IProductoRepositorio
    {
        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// Objeto de conexión a la base de datos.
        /// Se inicializa en el constructor y se utiliza para abrir y cerrar conexiones.
        /// </summary>
        private MySqlConnection _connection;
        /// <summary>
        /// Constructor que inicializa la cadena de conexión y prueba la conexión a la base de datos.
        /// </summary>
        public ProductoRepositorio()
        {
            _connectionString = "server=localhost;port=3306;database=PiercingsDB;uid=sa;password=123456;";
            _connection = new MySqlConnection(_connectionString);
            ProbarConexion();
        }
        /// <summary>
        /// Abre una conexión a la base de datos si está cerrada.
        /// </summary>
        public void AbrirConexion()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        /// <summary>
        /// Cierra la conexión a la base de datos si está abierta.
        /// </summary>
        private void CerrarConexion()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// Lanza una excepción si no se puede establecer la conexión.
        /// </summary>
        /// <returns>True si la conexión se establece correctamente, false en caso contrario.</returns>
        /// <exception cref="InvalidOperationException">Lanza si no se puede establecer la conexión.</exception>
        public bool ProbarConexion()
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
                if (producto.Id <= 0)
                {
                    producto = Crear(producto) ?? producto;
                }
                else
                {
                    var editado = Editar(producto);
                    if (editado == null)
                    {
                        throw new InvalidOperationException("No se pudo editar el producto.");
                    }
                }
                return producto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar producto: {ex.Message}");
                producto.Id = -1;
                throw new InvalidOperationException("Error al guardar el producto.");
            }
            finally
            {
                CerrarConexion();
            }
        }

        public Producto? Crear(Producto producto)
        {
            try
            {
                Producto p = new Producto()
                {
                    Nombre = producto.Nombre,
                    Categoria = producto.Categoria,
                    Color = producto.Color,
                    Inventario = producto.Inventario
                };
                string query = "INSERT INTO Productos (Nombre, CategoriaId, Color, Inventario) VALUES (@Nombre, @CategoriaId, @Color, @Inventario)";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@CategoriaId", (int)producto.Categoria);
                command.Parameters.AddWithValue("@Color", producto.Color);
                command.Parameters.AddWithValue("@Inventario", producto.Inventario);
                command.ExecuteNonQuery();
                p.Id = (int)command.LastInsertedId;
                return p;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                return null;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public Producto? Editar(Producto producto)
        {
            try
            {
                string query = "UPDATE Productos SET Nombre = @Nombre, CategoriaId = @CategoriaId, Color = @Color, Inventario = @Inventario WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", producto.Id);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@CategoriaId", (int)producto.Categoria);
                command.Parameters.AddWithValue("@Color", producto.Color);
                command.Parameters.AddWithValue("@Inventario", producto.Inventario);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return producto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar producto: {ex.Message}");
                return null;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
