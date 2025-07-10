<%@ Page Title="Crear Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="~/Pages/Clientes/Crear.aspx.cs" Inherits="WebFormsCrud.Pages.Clientes.Crear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2><asp:Literal ID="ltTitulo" runat="server" /></h2>

        <div class="card">
            <div class="card-body">
                <asp:HiddenField ID="hdnClienteId" runat="server" />

                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Nombre</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="100" required="required"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre es Requerido" CssClass="text-danger" />
                    </div>

                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">RUC/Cédula</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="txtCedula" CssClass="form-control" MaxLength="20" ></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-2">
                            <div class="col-sm-10">
                                <div class="form-check">
                                    <asp:CheckBox ID="chkConsumidorFinal" runat="server" CssClass="form-check-input" AutoPostBack="true" 
                                        OnCheckedChanged="chkConsumidorFinal_CheckedChanged" />
                                    <label class="form-check-label">¿Es consumidor final?</label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="pnlDatosFiscales" runat="server" Visible="false">
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Teléfono</label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" MaxLength="20" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Dirección</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" TextMode="MultiLine"
                                    Rows="2"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>

                    <div class="form-group row">
                        <div class="col-sm-10 offset-sm-2">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" 
                                OnClick="btnGuardar_Click" />
                            <asp:HyperLink ID="lnkCancelar" runat="server" NavigateUrl="~/Pages/Clientes/Listar.aspx"
                                CssClass="btn btn-secondary">Cancelar</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>