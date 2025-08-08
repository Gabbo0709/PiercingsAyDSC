using PiercingsOwner.Negocio.ModeloDeNegocio;
using PiercingsOwner.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiercingsOwner.Negocio
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoServicio()
        {
            _productoRepositorio = new ProductoRepositorio();
        }

        bool IProductoServicio.CrearProducto(Producto producto)
        {
            try
            {
                _productoRepositorio.Guardar(producto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool IProductoServicio.EditarProducto(Producto producto)
        {
            try
            {
                _productoRepositorio.Guardar(producto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        List<Producto> IProductoServicio.FiltrarProductosPorCategoria(List<Categoria> categorias)
        {
            return _productoRepositorio.BuscarPorCategoria(categorias);
        }

        Producto IProductoServicio.ObtenerProductoPorId(int id)
        {
            return _productoRepositorio.BuscarPorId(id);
        }

        List<Producto> IProductoServicio.ObtenerProductos()
        {
            return _productoRepositorio.BuscarTodos();
        }
    }
}
