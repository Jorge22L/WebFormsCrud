using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IClienteRepository
    {
        int GuardarCliente(Clientes cliente);
        bool ActualizarCliente(Clientes cliente);
        bool EliminarCliente(int id);
        Clientes ObtenerClientePorId(int id);
        List<Clientes> ObtenerTodosLosClientes();
    }
}
