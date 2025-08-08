using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiercingsOwner.Datos
{
    public interface IRepositorio<T> where T : class
    {
        T Guardar(T entidad);
        T BuscarPorId(int id);
        List<T> BuscarTodos();
        bool Deshabilitar(int id);
    }
}
