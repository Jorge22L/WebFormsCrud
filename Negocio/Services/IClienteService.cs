using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public interface IClienteService
    {
        (int Id, string Mensaje) GuardarCliente(Clientes cliente);
        bool ValidarRuc(string ruc);
        bool EliminarCliente(int id);
        Clientes ObtenerClientePorId(int id);
        List<Clientes> Listar(string filtro);

    }
}
