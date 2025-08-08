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


}
