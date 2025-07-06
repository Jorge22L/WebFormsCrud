using DAL.Repositories;
using Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsCrud.Pages.Clientes
{
    public partial class Listar : System.Web.UI.Page
    {
        private IClienteService _clienteService
        {
            get
            {
                if (Application["ClienteService"] == null)
                {
                    Application["ClienteService"] = new ClienteService(new ClienteRepository());
                }

                return (IClienteService)Application["ClienteService"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes(string filtro = null)
        {
            try
            {
                var clientes = _clienteService.Listar(filtro);
                gvClientes.DataSource = clientes;
                gvClientes.DataBind();
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
            }
        }

        private void MostrarExito(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "success",
                $"alert('{mensaje}');", true);
        }

        private void MostrarError(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error",
                 $"alert('Error: {mensaje}');", true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes(txtBusqueda.Text.Trim());
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect($"~/Pages/Clientes/Editar.aspx?id={e.CommandArgument}");
            }
            else if (e.CommandName == "Eliminar")
            {
                EliminarCliente(Convert.ToInt32(e.CommandArgument));
            }
        }

        private void EliminarCliente(int id)
        {
            try
            {
                var resultado = _clienteService.EliminarCliente(id);
                if (resultado)
                {
                    MostrarExito("Cliente eliminado correctamente");
                    CargarClientes(txtBusqueda.Text.Trim());
                }
                else
                {
                    MostrarError("No se pudo eliminar el cliente");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientes.PageIndex = e.NewPageIndex;
            CargarClientes(txtBusqueda.Text.Trim());
        }
    }
}