<%@ Page Title="" Language="C#" MasterPageFile="~/View/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuario/Carrito.aspx.cs" Inherits="View_usuario_Carrito" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1 class="text-center text-primary"><strong>Mi Carrito<br /><small>Listado de productos para compra</small></strong></h1>
    <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;">  
                 <asp:GridView ID="GV_carrito" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Carrito" DataSourceID="ODS_carrito" OnRowEditing="GV_carrito_RowEditing" OnRowUpdating="GV_carrito_RowUpdating" OnRowUpdated="GV_carrito_RowUpdated" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <Columns>
                         <asp:BoundField DataField="Nom_producto" HeaderText="Producto" SortExpression="Nom_producto" ReadOnly="true"/>
                         <asp:TemplateField HeaderText="Stock" SortExpression="Cant_Actual" >
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Cant_Actual") %>' ReadOnly="true"></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Cant_Actual" runat="server" Text='<%# Bind("Cant_Actual") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Cantidad Pedida" SortExpression="Cantidad">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TB_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>' TextMode="Number"></asp:TextBox>
                                 <asp:RangeValidator ID="RV_cantidad" runat="server" ErrorMessage="valor invalido" ControlToValidate="TB_Cantidad" MaximumValue='<%# Bind("Cant_Actual") %>' MinimumValue="1" Type="Integer"></asp:RangeValidator>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="LB_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" ReadOnly="true" />
                         <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" ReadOnly="true"/>
                         <asp:CommandField HeaderText="editar" ShowEditButton="True" />
                         <asp:CommandField HeaderText="eliminar" ShowDeleteButton="True" />
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
                     <EmptyDataTemplate>
                         <h1 class="text-center text-danger">no hay datos para mostrar</h1>
                     </EmptyDataTemplate>
                 </asp:GridView>
                 
                 <asp:ObjectDataSource ID="ODS_carrito" runat="server" DataObjectTypeName="Utilitarios.UEncapCarrito" SelectMethod="ObtenerCarritoxUsuario" TypeName="LogicaNegocio.LUsuario" UpdateMethod="ActualizarCarritoFactura">
                     <SelectParameters>
                         <asp:SessionParameter Name="usu" SessionField="userid" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </div>
        </div>
    </div>
          <asp:ObjectDataSource ID="ODS_Municipio" runat="server" SelectMethod="ConsultarMunicipio" TypeName="LogicaNegocio.LEmpleado">
                </asp:ObjectDataSource>  

    <div class="col-sm-12">
        <div class="form-inline text-block">
            <div class="form-group">
                <br />
                <br />
                <asp:DropDownList ID="DDL_Lugar" class="form-control" runat="server" AutoPostBack="True" DataSourceID="ODS_Municipio" DataTextField="Nombre" DataValueField="Id" OnSelectedIndexChanged="DDL_Lugar_SelectedIndexChanged" Width="245px">
                </asp:DropDownList>      
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="DDL_Lugar" ValidationGroup="dire"></asp:RequiredFieldValidator> 
                <asp:TextBox ID="TB_Direccion" runat="server" Class="form-control" placeholder="Dirreccion" Visible="False" Width="202px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TB_Direccion" ValidationGroup="dire"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
                
   
           
    <div class="inline text-center">
        <br />
            <asp:Button ID="BTN_facturar1" runat="server" Text="Facturar" ValidationGroup="dire" OnClick="BTN_facturar1_Click" Class="btn btn-primary" />
            <asp:Button ID="BTN_mas" runat="server" Text="Mas Productos" OnClick="BTN_mas_Click" Class="btn btn-primary" />     
    </div>
    <br />
    <br />
    <div class="text-center center-block" style=" width:50%;">
        <asp:Panel runat="server" ID="PanelMensaje" Visible="false" CssClass="alert alert-danger shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="B_cerrar_mensaje1" OnClick="B_cerrar_mensaje1_Click" />
        </asp:Panel>

        <asp:Panel runat="server" ID="PanelMensaje1" Visible="false" CssClass="alert alert-warning shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje1" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton1" OnClick="LinkButton1_Click" />
        </asp:Panel>

        <asp:Panel runat="server" ID="PanelMensaje2" Visible="false" CssClass="alert alert-success shadow" role="alert">
	        <strong>
	        <asp:Label ID="LblMensaje2" runat="server" />
	        </strong>
	        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton2" OnClick="LinkButton2_Click" />
        </asp:Panel>
    </div>
</asp:Content>

