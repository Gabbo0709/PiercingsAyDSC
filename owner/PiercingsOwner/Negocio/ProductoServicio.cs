using PiercingsOwner.Negocio.ModeloDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiercingsOwner.Negocio
{
    internal class ProductoServicio : IProductoServicio
    {
        public bool CrearProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool EditarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public List<Producto> FiltrarProductosPorCategoria(List<Categoria> categorias)
        {
            throw new NotImplementedException();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> ObtenerProductos()
        {
            throw new NotImplementedException();
        }
    }
}
