<%@ Page Title="" Language="C#" MasterPageFile="~/View/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controller/empleado/pedidosatender.aspx.cs" Inherits="View_empleado_pedidosatender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>PEDIDOS PARA ALISTAR</strong></h1>
    <br />
    <asp:Repeater ID="R_pedido" runat="server" DataSourceID="ODS_pedidos" OnItemCommand="R_pedido_ItemCommand">
        <ItemTemplate>
            <div class="card text-center bg-primary fa-border border-dark mb-5">
                <div class="card-header">
                    <strong>
                    <h1>Pedido No.<asp:Label ID="Id" runat="server" class="card-text" Text='<%# Eval("Id") %>' />
                    </h1>
                    </strong>
                </div>
                <div class="card-body">
                    <h3 class="card-text">Realizado:
                        <asp:Label ID="Label1" runat="server" class="card-text" Text='<%# Eval("Fecha_pedido") %>' />
                    </h3>
                    <h3 class="card-text">Cliente:
                        <asp:Label ID="Label2" runat="server" class="card-text" Text='<%# Eval("Usuario") %>' />
                    </h3>
                    <asp:Button ID="BTN_Detalles" runat="server" class="btn btn-primary" Text="Alistar" />
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <h3 class="text-center">
                <asp:Label ID="defaultItem" runat="server" CssClass="alert-danger" Text="NO HAY PEDIDOS PARA ALISTAR" Visible="<%# R_pedido.Items.Count == 0 %>" />
            </h3>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ODS_Productos" runat="server" SelectMethod="ObtenerProductos" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:SessionParameter Name="pedido" SessionField="idpedido" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="text-center center-block">
        <asp:Panel ID="PanelMensaje2" runat="server" CssClass="alert alert-success shadow" role="alert" Visible="false">
            <strong>
            <asp:Label ID="LblMensaje2" runat="server" />
            </strong>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="close" OnClick="LinkButton2_Click" Text="&lt;span aria-hidden='true'&gt;×&lt;/span&gt;" />
        </asp:Panel>
    </div>
    <br />
    <h1 class="text-center text-primary"><strong>TABLA DE PRODUCTOS</strong></h1>
    <br />
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
            <div>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">
                                <h3>Nombre Producto</h3>
                            </th>
                            <th scope="col">
                                <h3>Referencia</h3>
                            </th>
                            <th scope="col">
                                <h3>Cantidad solicitada</h3>
                            </th>
                            <th scope="col">
                                <h3>Total</h3>
                            </th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="R_pro" runat="server" DataSourceID="ODS_pro">
                        <ItemTemplate>
                            <tr>
                                <th scope="row">1</th>
                                <td>
                                    <asp:Label ID="Nom_produc" runat="server" class="card-text" Text='<%# Eval("Nombre_producto") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Referencia" runat="server" class="card-text" Text='<%# Eval("Referencia") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Cantidad" runat="server" class="card-text" Text='<%# Eval("Cantidad") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Total" runat="server" class="card-text" Text='<%# Eval("Total") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
    <div class="center-block">
        <asp:TextBox ID="TB_novedad" runat="server" class="form-group" placeholder="Ingrese novedades del pedido" TextMode="MultiLine" Width="37%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_novedad" ErrorMessage="*" ValidationGroup="novedad"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_novedad" ErrorMessage="Solo de admiten letras y numeros" Font-Size="" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z]+$"></asp:RegularExpressionValidator>
        &nbsp;<br />
        <asp:Button ID="BTN_confirmar" runat="server" class="btn btn-primary" OnClick="BTN_confirmar_Click" Text="Confirmar Alistamiento" ValidationGroup="novedad" />
        <br />
        <br />
        <asp:ObjectDataSource ID="ODS_pro" runat="server" SelectMethod="ObtenerProductos" TypeName="LogicaNegocio.LEmpleado">
            <SelectParameters>
                <asp:SessionParameter Name="pedido" SessionField="idpedido" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
    </div>
    <asp:ObjectDataSource ID="ODS_pedidos" runat="server" SelectMethod="ObtenerPedidos" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="user" SessionField="empleid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

