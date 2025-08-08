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
            Id = 1,
            Nombre = "Producto de prueba",
            Inventario = 10
        };

        // Simular que el producto ya existe en la base de datos
        repo.Crear(producto);
        // Descontar inventario
        var resultado = repo.Editar(producto.Id, producto.Inventario - 2);
        var productos = repo.BuscarTodos();
        var productoActualizado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoActualizado, "El producto no fue encontrado después de la actualización.");
        Assert.AreEqual(8, productoActualizado.Inventario, "El inventario no se actualizó correctamente.");
    }

    // Prueba que no se pueda descontar más inventario del disponible
    [TestMethod]
    public void DescontarInventarioNoExitosoTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = 1,
            Color = "Rojo",
            Inventario = 10
        };

        // Simular que el producto ya existe en la base de datos
        repo.Crear(producto);

        // Intentar descontar más inventario del que hay disponible
        var resultado = repo.Editar(producto.Id, producto.Inventario - 2);
        var productos = repo.BuscarTodos();
        var productoActualizado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoActualizado, "El producto no fue encontrado después de la actualización.");
        Assert.AreEqual(0, productoActualizado.Inventario, "El inventario no se actualizó correctamente.");
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
            Categoria = 1,
            Color = "Rojo",
            Inventario = 8
        };

        // Simular que el producto ya existe en la base de datos
        repo.Crear(producto);

        // Aumentar inventario por devolución
        var resultado = repo.Editar(producto.Id, producto.Inventario + 2);
        var productos = repo.BuscarTodos();
        var productoActualizado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoActualizado, "El producto no fue encontrado después de la actualización.");
        Assert.AreEqual(10, productoActualizado.Inventario, "El inventario no se actualizó correctamente.");
    }

    // Prueba que no se pueda procesar devolución en un producto deshabilitado
    [TestMethod]
    public void ProcesarDevolucionesNoExitosamenteTest()
    { 
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = 1,
            Color = "Rojo",
            Inventario = 0,
        };

        repo.Crear(producto);
        repo.Deshabilitar(producto.Id);

        // Intentar aumentar inventario de un producto deshabilitado
        var resultado = repo.Editar(producto.Id, producto.Inventario + 2);
        var productos = repo.BuscarTodos();
        var productoActualizado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoActualizado, "El producto no fue encontrado después de la actualización.");
        Assert.AreEqual(0, productoActualizado.Inventario, "El inventario no se actualizó correctamente.");
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
            Categoria = 1,
            Color = "Rojo",
            Inventario = 10
        };

        // Agregar el producto
        var resultado = repo.Crear(producto);
        Assert.IsTrue(resultado, "El producto no se agregó correctamente.");

        // Verificar que el producto se haya agregado
        var productos = repo.BuscarTodos();
        Assert.IsTrue(productos.Any(p => p.Nombre == producto.Nombre), "El producto no fue encontrado en la base de datos.");
    }

    // Prueba que no se pueda crear un producto con nombre inválido
    [TestMethod]
    public void CrearUnProductoNoExitosamenteTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "", // Nombre inválido
            Categoria = 1,
            Color = "Rojo",
            Inventario = 10
        };

        // Intentar agregar el producto con nombre inválido
        var resultado = repo.Crear(producto);
        Assert.IsFalse(resultado, "El producto con nombre inválido se agregó incorrectamente.");

        // Verificar que el producto no se haya agregado
        var productos = repo.BuscarTodos();
        Assert.IsFalse(productos.Any(p => p.Nombre == producto.Nombre), "El producto inválido fue encontrado en la base de datos.");
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
            Categoria = 1,
            Color = "Rojo",
            Inventario = 10
        };

        // Agregar el producto
        var resultado = repo.Crear(producto);
        Assert.IsTrue(resultado, "El producto no se agregó correctamente.");

        // Editar el producto
        producto.Nombre = "Producto editado";
        var editarResultado = repo.Editar(producto.Id, producto.Inventario);
        Assert.IsTrue(editarResultado, "El producto no se editó correctamente.");

        // Verificar que el producto se haya editado
        var productos = repo.BuscarTodos();
        var productoEditado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoEditado, "El producto no fue encontrado en la base de datos.");
        Assert.AreEqual("Producto editado", productoEditado.Nombre, "El nombre del producto no se actualizó correctamente.");
    }

    // Prueba que no se pueda editar un producto con nombre inválido
    [TestMethod]
    public void EditarUnProductoNoExitosamenteTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = 1,
            Color = "Rojo",
            Inventario = 10
        };

        var resultado = repo.Crear(producto);
        Assert.IsTrue(resultado, "El producto no se agregó correctamente.");

        producto.Nombre = ""; // Nombre inválido
        var editarResultado = repo.Editar(producto.Id, producto.Inventario);
        Assert.IsFalse(editarResultado, "El producto con nombre inválido se editó incorrectamente.");

        // Verificar que el producto no se haya editado
        var productos = repo.BuscarTodos();
        var productoNoEditado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoNoEditado, "El producto no fue encontrado en la base de datos.");
        Assert.AreEqual("Producto de prueba", productoNoEditado.Nombre, "El nombre del producto se actualizó incorrectamente.");
    }

    // FIN HU-11

    // HU-13 Desactivar un producto.

    // Prueba la desactivación exitosa de un producto
    [TestMethod]
    public void DesactivarUnProductoExitosamenteTest()
    {
        var repo = new ProductoRepositorio();
        var producto = new Producto
        {
            Nombre = "Producto de prueba",
            Categoria = 1,
            Color = "Rojo",
            Inventario = 10
        };

        // Agregar el producto
        var resultado = repo.Crear(producto);
        Assert.IsTrue(resultado, "El producto no se agregó correctamente.");

        // Desactivar el producto
        var desactivarResultado = repo.Deshabilitar(producto.Id);
        Assert.IsTrue(desactivarResultado, "El producto no se desactivó correctamente.");

        // Verificar que el producto se haya desactivado
        var productos = repo.BuscarTodos();
        var productoDesactivado = productos.FirstOrDefault(p => p.Id == producto.Id);
        Assert.IsNotNull(productoDesactivado, "El producto no fue encontrado en la base de datos.");
        Assert.AreEqual(0, productoDesactivado.Inventario, "El inventario del producto no es cero después de la desactivación.");
    }
}
