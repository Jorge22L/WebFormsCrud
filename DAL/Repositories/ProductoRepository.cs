using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CRUD_PedidosEntities _db;
        public bool ActualizarProducto(Productos producto)
        {
            try
            {
                _db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                return _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                return false;
            }
        }

        public bool EliminarProducto(int id)
        {
            var producto = _db.Productos.Find(id);
            if (producto == null)
            {
                return false; // Producto no encontrado
            }
            try
            {
                _db.Productos.Remove(producto);
                return _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                // Manejo de excepciones, podrías registrar el error o lanzar una excepción personalizada
                return false;
            }
        }

        public int GuardarProducto(Productos producto)
        {
            try
            {
                _db.Productos.Add(producto);
                _db.SaveChanges();
                return producto.ProductoId; // Asumiendo que el Id es autogenerado por la base de datos
            }
            catch (Exception)
            {
                return -1; // Manejo de errores, podrías lanzar una excepción personalizada o registrar el error
            }
        }

        public Productos ObtenerProductoPorId(int id)
        {
            var producto = _db.Productos.Find(id);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Producto con ID {id} no encontrado.");
            }
            return producto;
        }

        public List<Productos> ObtenerTodosLosProductos()
        {
            var productos = _db.Productos.ToList();
            if (productos == null || !productos.Any())
            {
                throw new InvalidOperationException("No se encontraron productos en la base de datos.");
            }
            return productos;
        }
    }
}
