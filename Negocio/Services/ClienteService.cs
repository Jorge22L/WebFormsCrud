using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool EliminarCliente(int id)
        {
            try
            {
                return _clienteRepository.EliminarCliente(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error al eliminar cliente: {e.Message}");
            }
        }

        public (int Id, string Mensaje) GuardarCliente(Clientes cliente)
        {
            if (!ValidarRuc(cliente.Cedula))
            {
                return (-1, "RUC inválido");
            }

            try
            {
                int id = _clienteRepository.GuardarCliente(cliente);
                return (id, "Cliente guardado correctamente");
            }
            catch (Exception e)
            {
                return (-1, $"Error al guardar el cliente: {e.Message}");
            }
        }

        public List<Clientes> Listar(string filtro)
        {
            try
            {
                var clientes = _clienteRepository.ObtenerTodosLosClientes();
                if(!string.IsNullOrEmpty(filtro))
                {
                    clientes = clientes.Where(c => 
                    c.Nombre.Contains(filtro) || 
                    (c.Cedula != null && c.Cedula.Contains(filtro))
                    ).ToList();
                }

                return clientes;
            }
            catch (Exception e)
            {
                throw new Exception($"Error al listar clientes: {e.Message}");
            }
        }

        public Clientes ObtenerClientePorId(int id)
        {
            try
            {
                return _clienteRepository.ObtenerClientePorId(id);
            }
            catch (Exception e)
            {
                throw new Exception($"Error al obtener cliente por ID: {e.Message}");
            }
        }

        public bool ValidarRuc(string ruc)
        {
            if (string.IsNullOrEmpty(ruc)) return true; // Consumidor final

            return Regex.IsMatch(ruc, @"^([Jj]-\d{3}-\d{3}-\d{3}[A-Za-z]?|\d{3}-\d{6}-\d{4}[A-Za-z]?)$");
        }
    }
}
