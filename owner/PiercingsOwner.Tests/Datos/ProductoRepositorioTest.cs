using PiercingsOwner.Negocio.ModeloDeNegocio;
using PiercingsOwner.Datos;

namespace PiercingsOwner.Tests;

[TestClass]
public class ProductoRepositorioTest
{
    [TestMethod]
    public void ConexionTest()
    {
        var repo = new ProductoRepositorio();
        var conexion = repo.ProbarConexion();
        Assert.IsTrue(conexion);
    }

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
}
