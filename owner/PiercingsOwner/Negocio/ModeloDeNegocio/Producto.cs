using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiercingsOwner.Negocio.ModeloDeNegocio;
/// <summary>
/// Represents a product with specific attributes such as ID, name, category, color, and inventory.
/// </summary>
internal class Producto
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    public Categoria Categoria { get; set; }

    /// <summary>
    /// Gets or sets the color of the product.
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Gets or sets the inventory count of the product.
    /// </summary>
    public int Inventario { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Producto"/> class.
    /// </summary>
    public Producto()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Producto"/> class with specified values.
    /// </summary>
    /// <param name="id">The unique identifier for the product.</param>
    /// <param name="nombre">The name of the product.</param>
    /// <param name="categoria">The category of the product.</param>
    /// <param name="color">The color of the product.</param>
    /// <param name="inventario">The inventory count of the product.</param>
    public Producto(int id, string nombre, int categoria, string color, int inventario)
    {
        Id = id;
        Nombre = nombre;
        Categoria = ParseCategoria(categoria);
        Color = color;
        Inventario = inventario;
    }

    public Categoria ParseCategoria(int categoriaId)
    {
        return categoriaId switch
        {
            1 => Categoria.ANILLO,
            2 => Categoria.PIERCING,
            3 => Categoria.ATRAPASUENO,
            _ => throw new ArgumentOutOfRangeException(nameof(categoriaId), "Invalid category ID")
        };
    }
}
