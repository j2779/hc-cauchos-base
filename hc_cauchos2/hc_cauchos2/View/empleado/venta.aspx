<%@ Page Title="" Language="C#" MasterPageFile="~/View/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controller/empleado/venta.aspx.cs" Inherits="View_empleado_venta" %>

<%@ Register Src="~/View/empleado/SectionLevelTutorialListingl.ascx" TagPrefix="uc1" TagName="SectionLevelTutorialListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 class="text-center text-primary"><strong>VENTA</strong></h1>
    <asp:TextBox ID="TB_NomCliente" runat="server" CssClass="form-control-static" placeholder="Cedula Cliente A Buscar"></asp:TextBox>
    <asp:Button ID="BTN_BuscarClien" runat="server" class="btn btn-primary" OnClick="BTN_BuscarClien_Click" Text="Buscar" />
    <asp:Button ID="BTN_buscarTodos" runat="server" CssClass="btn btn-primary" OnClick="BTN_buscarTodos_Click" Text="Todos" />
    <asp:Button ID="BTN_RegistrarCliente" runat="server" CssClass="btn btn-primary" OnClick="BTN_RegistrarCliente_Click" Text="Registrar" />
    <br />
    <br />
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
            <div>
                <asp:GridView ID="GV_Clientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" class="table table-hover" DataKeyNames="User_id" DataSourceID="ODS_Clientes" ForeColor="#333333" GridLines="None" OnRowUpdated="GV_Clientes_RowUpdated" PageSize="5" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="User_id" HeaderText="Identificador" SortExpression="User_id" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
                        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ODS_Clientes" runat="server" SelectMethod="ObtenerClientes" TypeName="LogicaNegocio.LEmpleado"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_ClientesCedu" runat="server" SelectMethod="ObtenerClientesCedula" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="TB_NomCliente" Name="cedula" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <div class="text-center center-block">
        <asp:Panel ID="PanelMensaje" runat="server" CssClass="alert alert-danger shadow" role="alert" Visible="false">
            <strong>
            <asp:Label ID="LblMensaje" runat="server" />
            </strong>
            <asp:LinkButton ID="B_cerrar_mensaje1" runat="server" CssClass="close" OnClick="B_cerrar_mensaje1_Click" Text="&lt;span aria-hidden='true'&gt;×&lt;/span&gt;" />
        </asp:Panel>
        <asp:Panel ID="PanelMensaje1" runat="server" CssClass="alert alert-warning shadow" role="alert" Visible="false">
            <strong>
            <asp:Label ID="LblMensaje1" runat="server" />
            </strong>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="close" OnClick="LinkButton1_Click" Text="&lt;span aria-hidden='true'&gt;×&lt;/span&gt;" />
        </asp:Panel>
        <asp:Panel ID="PanelMensaje2" runat="server" CssClass="alert alert-success shadow" role="alert" Visible="false">
            <strong>
            <asp:Label ID="LblMensaje2" runat="server" />
            </strong>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="close" OnClick="LinkButton2_Click" Text="&lt;span aria-hidden='true'&gt;×&lt;/span&gt;" />
        </asp:Panel>
    </div>
    <br />
    <hr />
    <h1 class="text-center"><strong>PRODUCTOS FACTURADOS</strong></h1>
    <asp:TextBox ID="TB_Iduser" runat="server" CssClass="form-control-static" placeholder="Agrege el identificador del usuario"></asp:TextBox>
    <br />
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" class="table table-hover" DataKeyNames="Id_Carrito" DataSourceID="ODS_Ventas" ForeColor="#333333" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Nom_producto" HeaderText="Producto" ReadOnly="true" SortExpression="Nom_producto" />
                        <asp:BoundField DataField="Cant_Actual" HeaderText="Stock" ReadOnly="true" SortExpression="Cant_Actual" />
                        <asp:TemplateField HeaderText="Cantidad Pedida" SortExpression="Cantidad">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cantidad") %>' TextMode="Number"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="true" SortExpression="Precio" />
                        <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="true" SortExpression="Total" />
                        <asp:CommandField HeaderText="Editar" ShowEditButton="True" />
                        <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ODS_Ventas" runat="server" DataObjectTypeName="Utilitarios.UEncapCarrito" DeleteMethod="EliminarItemCarrito" SelectMethod="ObtenerCarritoxUsuario" TypeName="LogicaNegocio.LEmpleado" UpdateMethod="ActualizarCarritoFactura">
                    <SelectParameters>
                        <asp:SessionParameter Name="usuario" SessionField="userid" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>
    <!--
    <asp:ImageButton ID="BTN_Facturar" runat="server" ImageUrl="~/ima/business-and-finance(1).png" OnClick="BTN_Facturar_Click" />
    -->
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="LB_facturar" runat="server" Text="Facturar"></asp:Label>
    <uc1:SectionLevelTutorialListing ID="SectionLevelTutorialListing" runat="server" />
</asp:Content>

