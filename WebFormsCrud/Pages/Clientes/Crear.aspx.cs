using DAL;
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
    public partial class Crear : System.Web.UI.Page
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

        private int? ClienteId
        {
            get
            {
                if (Request.QueryString["id"] == null) return null;

                int id;
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    MostrarError("ID de cliente no válido");
                    Response.Redirect("~/Pages/Clientes/Listar.aspx");
                    return null;
                }
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(ClienteId > 0)
                {
                    CargarDatosCliente();
                    ltTitulo.Text = "Editar Cliente";
                }
                else
                {
                    ltTitulo.Text = "Crear Cliente";
                }
            }
        }

        private void CargarDatosCliente()
        {
            // Aquí podrías cargar datos del cliente si es necesario
            try
            {
                var cliente = _clienteService.ObtenerClientePorId(int.Parse(ClientID));
                hdnClienteId.Value = cliente.ClienteId.ToString();
                txtNombre.Text = cliente.Nombre;
                txtCedula.Text = cliente.Cedula;
                chkConsumidorFinal.Checked = cliente.EsConsumidorFinal ?? false;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Direccion;
                pnlDatosFiscales.Visible = !cliente.EsConsumidorFinal.GetValueOrDefault();
            }
            catch (Exception e)
            {
                MostrarError(e.Message);
                //Response.Redirect("~/Pages/Clientes/Listar.aspx");
            }
        }

        protected void chkConsumidorFinal_CheckedChanged(object sender, EventArgs e)
        {
            pnlDatosFiscales.Visible = !chkConsumidorFinal.Checked;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var cliente = new DAL.Clientes
            {
                ClienteId = ClienteId ?? 0,
                Nombre = txtNombre.Text.Trim(),
                Cedula = txtCedula.Text.Trim(),
                EsConsumidorFinal = chkConsumidorFinal.Checked,
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            try
            {
                var (id, mensaje) = _clienteService.GuardarCliente(cliente);
                if (id > 0)
                {
                    MostrarExito(mensaje);
                    Response.Redirect("~/Pages/Clientes/Listar.aspx");
                }
                else
                {
                    MostrarError(mensaje);
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        protected void MostrarExito(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "success",
                $"alert('{mensaje}');", true);
        }

        protected void MostrarError(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error",
                $"alert('Error: {mensaje}');", true);
        }
    }
}