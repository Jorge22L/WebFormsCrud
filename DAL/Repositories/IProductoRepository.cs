using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProductoRepository
    {
        int GuardarProducto(Productos producto);
        bool ActualizarProducto(Productos producto);
        bool EliminarProducto(int id);
        Productos ObtenerProductoPorId(int id);
        List<Productos> ObtenerTodosLosProductos();
    }
}
