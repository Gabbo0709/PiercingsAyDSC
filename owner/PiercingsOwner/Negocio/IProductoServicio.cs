using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PiercingsOwner.Negocio.ModeloDeNegocio;

namespace PiercingsOwner.Negocio
{
    internal interface IProductoServicio
    {
        bool CrearProducto(Producto producto);
        bool EditarProducto(Producto producto);
        Producto ObtenerProductoPorId(int id);
        List<Producto> FiltrarProductosPorCategoria(List<Categoria> categorias);
        List<Producto> ObtenerProductos();
    }
}
