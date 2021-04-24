<%@ Page Title="" Language="C#" MasterPageFile="~/View/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuario/pedidos_finalizados.aspx.cs" Inherits="View_usuario_pedidos_finalizados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>PEDIDOS FINALIZADOS
        <br />
        <small>la lista se reiniciara mensualmente</small></strong></h1>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_pedidos_fin" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <div id="carta" class="card text-center bg-primary fa-border border-dark mb-5 col-sm-6">
                <div class="card-header">
                    <strong>
                    <h1>Pedido No.<asp:Label ID="Id" runat="server" class="card-text" Text='<%# Eval("Id") %>' />
                    </h1>
                    </strong>
                </div>
                <div class="card-body">
                    <h4 class="card-text"><strong>Realizado el dia: </strong>
                        <asp:Label ID="Label1" runat="server" class="card-text" Text='<%# Eval("Fecha_pedido") %>' />
                    </h4>
                    <h4 class="card-text"><strong>Lugar de entrega:
                        <asp:Label ID="Label3" runat="server" class="card-text" Text='<%# Eval("Ciudad_dep") %> ' />
                        </strong></h4>
                    <h4 class="card-text"><strong>Direccion: </strong>
                        <asp:Label ID="Label5" runat="server" class="card-text" Text='<%# Eval("Direccion") %>' />
                    </h4>
                    <h4 class="card-text"><strong>Estado: </strong>
                        <asp:Label ID="Label6" runat="server" class="card-text" Text='<%# Eval("Estado") %>' />
                    </h4>
                    <h4 class="card-text"><strong>Empleados: </strong>EMPLEADO(<asp:Label ID="Label8" runat="server" class="card-text" Text='<%# Eval("Empleado") %>' />
                        ) DOMICILIARIO(<asp:Label ID="Label7" runat="server" class="card-text" Text='<%# Eval("Domiciliaro") %>' />
                        )</h4>
                    <h4 class="card-text"><strong>Fecha de entrega: </strong>
                        <asp:Label ID="Label2" runat="server" class="card-text" Text='<%# Eval("Fecha_pedido_fin") %>' />
                    </h4>
                    <h4 class="card-text"><strong>Novedad: </strong>
                        <asp:Label ID="Label4" runat="server" class="card-text" Text='<%# Eval("Novedad") %>' />
                    </h4>
                    <asp:Button ID="BTN_factura" runat="server" class="btn btn-primary center-block" Text="Ver factura" />
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <h3 class="text-center">
                <asp:Label ID="defaultItem" runat="server" CssClass="alert-danger" Text="NO TIENE PEDIDOS FINALIZADOS" Visible="<%# Repeater1.Items.Count == 0 %>" />
            </h3>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ODS_pedidos_fin" runat="server" SelectMethod="ObtenerPedidosFin" TypeName="LogicaNegocio.LUsuario">
        <SelectParameters>
            <asp:SessionParameter Name="usu" SessionField="clienid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

