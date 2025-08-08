using PiercingsOwner.Negocio.ModeloDeNegocio;
using PiercingsOwner.Datos;

namespace PiercingsOwner.Tests;

[TestClass]
public class ProductoRepositorioTest
{
    // Prueba la conexión a la base de datos
    [TestMethod]
    public void ConexionTest()
    {
        var repo = new ProductoRepositorio();
        var conexion = repo.ProbarConexion();
        Assert.IsTrue(conexion);
    }

    // Verifica que al consultar todos los productos en una base vacía, la lista esté vacía
    [TestMethod]
    public void ObtenerTodosConBaseDeDatosVaciaTest()
    {
        var repo = new ProductoRepositorio();
        var productos = repo.BuscarTodos();
        Assert.IsNotNull(productos);
        Assert.IsInstanceOfType(productos, typeof(List<Producto>));
        Assert.AreEqual(
            0,
            productos.Count, 
            "La cantidad de productos en la " +
            $"base de datos no es la esperada. Se esperaban 0 y se recibieron {productos.Count}"
        );
    }

    // HU-05

    // Prueba que se descuente correctamente el inventario de un producto existente
    [TestMethod]
    public void DescontarInventarioCorrectamenteTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = Categoria.ANILLO,
            Color = "Rojo",
            Inventario = 10,
        };
        // Usa el producto retornado por Crear, que tiene el Id asignado
        var a = repo.Crear(producto);
        a.Inventario -= 2;
        Assert.IsNotNull(repo.Editar(a), "El producto no fue editado correctamente.");
    }

    // FIN HU-05

    // HU-07

    // Prueba que se procesen devoluciones exitosamente (aumentando inventario)
    [TestMethod]
    public void ProcesarDevolucionesExitosamenteTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = Categoria.ANILLO,
            Color = "Rojo",
            Inventario = 5,
        };
        // Usa el producto retornado por Crear, que tiene el Id asignado
        var a = repo.Crear(producto);
        a.Inventario += 2;
        Assert.IsNotNull(repo.Editar(a), "El producto no fue editado correctamente.");
    }

    // FIN HU-07

    // HU-09

    // Prueba la creación exitosa de un producto
    [TestMethod]
public void CrearUnProductoExitosamenteTest()
{
    var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = Categoria.ANILLO,
            Color = "Rojo",
            Inventario = 10,

        };

    Assert.IsNotNull(repo.Crear(producto), "El producto no se agregó correctamente.");
}

    // FIN HU-09

    // HU-11 Editar la información de un producto.

    // Prueba la edición exitosa de un producto
    [TestMethod]
    public void EditarUnProductoExitosamenteTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = Categoria.ANILLO,
            Color = "Rojo",
            Inventario = 10,
        };

        // Agregar el producto
        var a = repo.Crear(producto);
        a.Nombre = "Cambio de prueba";
        Assert.IsNotNull(repo.Editar(a), "El producto no se editó correctamente.");
    }

    // FIN HU-11
}
