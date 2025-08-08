using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiercingsOwner.Negocio.ModeloDeNegocio;

namespace PiercingsOwner.Datos
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        List<Producto> BuscarPorCategoria(List<Categoria> categorias);
    }
}
