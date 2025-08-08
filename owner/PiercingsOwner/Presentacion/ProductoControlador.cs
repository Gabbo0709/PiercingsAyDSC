using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiercingsOwner.Negocio.ModeloDeNegocio;

namespace PiercingsOwner.Presentacion
{
    public class ProductoControlador
    {
        public bool CrearProducto(Producto producto)
        {
            return true;
        }
        public bool EditarProducto(Producto producto)
        {
            return true;
        }
        public Producto VerDetallesProducto(int id)
        {
            // Solución: Usar inicialización de objeto para establecer todos los miembros requeridos
            return new Producto
            {
                Id = id,
                Nombre = "Producto de Ejemplo",
                Categoria = Categoria.ANILLO, // Asignar una categoría por defecto
                Color = "Rojo",
                Inventario = 100
            };
        }
        public List<Producto> VerProductos()
        {
            return new List<Producto>();
        }
        public bool RegistrarEntrada(Producto producto, int cantidad)
        {
            if (cantidad <= 0)
            {
                return false; // No se puede registrar una entrada con cantidad negativa o cero
            }
            producto.Inventario += cantidad;
            return true; // Registro exitoso
        }
        public bool RegistrarSalida(Producto producto, int cantidad)
        {
            if (cantidad <= 0 || producto.Inventario < cantidad)
            {
                return false; // No se puede registrar una salida con cantidad negativa, cero o mayor al inventario
            }
            producto.Inventario -= cantidad;
            return true; // Registro exitoso
        }
        public bool DeshabilitarProducto(Producto producto)
        {
            return true; // Asumimos que la operación fue exitosa
        }
    }
}
