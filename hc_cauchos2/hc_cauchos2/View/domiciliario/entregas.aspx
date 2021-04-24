<%@ Page Title="" Language="C#" MasterPageFile="~/View/domiciliario/domiciliario_master.master" AutoEventWireup="true" CodeFile="~/Controller/domiciliario/entregas.aspx.cs" Inherits="View_domiciliario_entregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>PEDIDOS PARA ENTREGAR</strong></h1>
    <br />
    <asp:Repeater ID="R_pedido" runat="server" DataSourceID="ODS_entregas" OnItemCommand="R_pedido_ItemCommand">
        <ItemTemplate>
            <div id="carta" class="card text-center bg-primary fa-border border-dark mb-5 col-sm-6">
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
                    <h3 class="card-text">Ciudad:
                        <asp:Label ID="Label4" runat="server" class="card-text" Text='<%# Eval("Municipio") %>' />
                    </h3>
                    <h3 class="card-text">Direccion:
                        <asp:Label ID="Label5" runat="server" class="card-text" Text='<%# Eval("Direccion") %>' />
                    </h3>
                    <asp:Button ID="BTN_Detalles" runat="server" class="btn btn-primary" Text="Entregado" />
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <h3 class="text-center">
                <asp:Label ID="defaultItem" runat="server" CssClass="alert-danger" Text="NO HAY PEDIDOS PARA ALISTAR" Visible="<%# R_pedido.Items.Count == 0 %>" />
            </h3>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ODS_entregas" runat="server" SelectMethod="pedidosdomiciliario" TypeName="LogicaNegocio.LDomiciliario">
        <SelectParameters>
            <asp:SessionParameter Name="user" SessionField="domiid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

