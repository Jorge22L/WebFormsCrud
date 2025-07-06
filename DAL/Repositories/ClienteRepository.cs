using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CRUD_PedidosEntities _db = new CRUD_PedidosEntities();
        public bool ActualizarCliente(Clientes cliente)
        {
            try
            {
                _db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                return _db.SaveChanges() > 0; // True si guardó
            }
            catch (Exception)
            {
                return false; // False si hubo un error
            }
        }

        public bool EliminarCliente(int id)
        {
            var cliente = _db.Clientes.Find(id);
            if (cliente == null)
            {
                return false; // Cliente no encontrado
            }

            _db.Clientes.Remove(cliente);
            return _db.SaveChanges() > 0; // True si eliminó
        }

        public int GuardarCliente(Clientes cliente)
        {
            try
            {
                _db.Clientes.Add(cliente);
                _db.SaveChanges();
                return cliente.ClienteId; // Retorna el ID del cliente guardado
            }
            catch (Exception)
            {
                return -1; // Retorna -1 si hubo un error al guardar
            }
        }

        public Clientes ObtenerClientePorId(int id)
        {
            var cliente = _db.Clientes.Find(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente no encontrado");
            }
            return cliente; // Retorna el cliente encontrado
        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            var clientes = _db.Clientes.ToList();
            if (clientes == null || !clientes.Any())
            {
                throw new InvalidOperationException("No hay clientes registrados");
            }
            return clientes; // Retorna la lista de todos los clientes
        }
    }
}
