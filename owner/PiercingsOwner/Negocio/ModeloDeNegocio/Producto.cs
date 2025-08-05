using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiercingsOwner.Negocio.ModeloDeNegocio;
internal class Producto
{
    public required int Id { get; set; }
    public required string Nombre { get; set; }
    public required Categoria Categoria { get; set; }
    public required string Color { get; set; }
    public required int Inventario { get; set; }
    public Producto()
    {
    }
    public Producto(int id, string nombre, Categoria categoria, string color, int inventario)
    {
        Id = id;
        Nombre = nombre;
        Categoria = categoria;
        Color = color;
        Inventario = inventario;
    }
}
