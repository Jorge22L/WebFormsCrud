<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Listar.aspx.cs" Debug="true" Inherits="WebFormsCrud.Pages.Clientes.Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Gestión de Clientes</h2>

        <!-- Panel de Búsqueda -->
        <div class="card mb-3">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Nombre o RUC">

                        </asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    </div>

                    <div class="col-md-6 text-right">
                        <asp:HyperLink ID="lnkNuevo" runat="server" NavigateUrl="#" CssClass="btn btn-success">
                            <i class="fas fa-plus"></i> Nuevo Cliente
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>

        <!-- GridView -->
        <asp:GridView ID="gvClientes" runat="server" 
            AutoGenerateColumns="false" 
            CssClass="table table-striped table-bordered table-hover"
            DataKeyNames="ClienteId"
            AllowPaging="true"
            PageSize="10"
            OnPageIndexChanging="gvClientes_PageIndexChanging"
            OnRowCommand="gvClientes_RowCommand"
            EmptyDataText="No se encontraron clientes"
            PagerStyle-CssClass="pagination"
            PagerSettings-Mode="NumericFirstLast"
            PagerSettings-Position="Bottom"
            PagerSettings-PageButtonCount="5">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Cedula" HeaderText="RUC/Cédula" />
                <asp:TemplateField HeaderText="Cons. Final">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkConsumidor" runat="server" Checked='<%# Eval("EsConsumidorFinal") %>' Enabled="false"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar"
                            CommandArgument='<%# Eval("ClienteId") %>'
                            CssClass="btn btn-sm btn-outline-primary"
                            ToolTip="Editar">
                            <i class="fas fa-edit"></i>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar"
                            CommandArgument='<%# Eval("ClienteId") %>'
                            CssClass="btn btn-sm btn-outline-danger"
                            ToolTip="Eliminar"
                            OnClientClick="return confirm('¿Estás seguro que deseas eliminar este cliente?');">
                            <i class="fas fa-trash-alt"></i>
                        </asp:LinkButton>
                        <asp:HyperLink ID="btnDetalles" runat="server"
                            NavigateUrl='<%# $"~/Pages/Clientes/Detalles.aspx?id={Eval("ClienteId")}" %>'
                            CssClass="btn btn-sm btn-outline-info"
                            ToolTip="Detalles">
                            <i class="fas fa-eye"></i>

                        </asp:HyperLink>
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>


        </asp:GridView>

       
    </div>
</asp:Content>
