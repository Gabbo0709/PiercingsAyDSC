using PiercingsOwner.Negocio.ModeloDeNegocio;
using PiercingsOwner.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiercingsOwner.Negocio
{
    internal class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoServicio()
        {
            _productoRepositorio = new ProductoRepositorio();
        }

        public bool CrearProducto(Producto producto)
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

        public bool EditarProducto(Producto producto)
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

        public List<Producto> FiltrarProductosPorCategoria(List<Categoria> categorias)
        {
            return _productoRepositorio.BuscarPorCategoria(categorias);
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _productoRepositorio.BuscarPorId(id);
        }

        public List<Producto> ObtenerProductos()
        {
            return _productoRepositorio.BuscarTodos();
        }
    }
}
