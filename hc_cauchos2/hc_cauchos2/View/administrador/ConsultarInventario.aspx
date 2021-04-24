<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/ConsultarInventario.aspx.cs" Inherits="View_administrador_ConsultarInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1 class="text-center"><strong>Ver - Editar - Inhabilitar Productos</strong></h1>
     <div class="row">
        

        <div class=" col-lg-12 col-md-offset-0.3">
              
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                <asp:TextBox ID="TB_Buscar" runat="server" placeholder="Referencia a buscar" CssClass="form-control-static" Width="161px"  ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BT_Inabilitar" runat="server" CssClass="btn btn-primary" Text="Inabilitar" OnClick="BT_Inabilitar_Click" />
                &nbsp;<asp:Button ID="BT_Filtrar" runat="server" CssClass="btn btn-primary" Text="Filtrar" OnClick="BT_Filtrar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DDL_Marca2" CssClass="form-control-static" runat="server" DataSourceID="ODS_ConsularMarca" DataTextField="Marca" DataValueField="Id" >
                    <asp:ListItem Value="0">Marca</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:DropDownList ID="DDL_Categoria2" CssClass="form-control-static" runat="server" DataSourceID="ODS_ConsultarCategoria" DataTextField="Categoria" DataValueField="Id"></asp:DropDownList>
                 &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="BT_Buscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BT_Buscar_Click" OnClientClick="inabilitar()" />
                <asp:Button ID="Button1" runat="server" Text="Todos" CssClass="btn btn-primary" OnClick="Button1_Click" />
                <asp:ObjectDataSource ID="ODS_ConsultarCategoria" runat="server" SelectMethod="ConsultarCategoria" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
               
               
               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                
               
                <asp:ObjectDataSource ID="ODS_ConsularMarca" runat="server" SelectMethod="ConsultarMarca" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
           
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
        </div>
    </div>


    <div class="row">
        
        <div class=" col-lg-12 col-md-offset-0.5">

               
         
                <br />
                <br />
             <div style="overflow-x: auto;">  
            
            <asp:GridView ID="GV_inventario"  runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="GV_inventario_RowDataBound" CssClass="auto-style1" ForeColor="#333333" GridLines="None" Width="1691px" DataSourceID="ODS_Inventario" DataKeyNames="Id" OnRowUpdating="GV_inventario_RowUpdating" OnRowEditing="GV_inventario_RowEditing" AllowPaging="True" OnPageIndexChanging="GV_inventario_PageIndexChanging" PageSize="5" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />

                    <asp:TemplateField HeaderText="Imagen">

                        <EditItemTemplate>
                            <asp:FileUpload ID="fu_imagen" runat="server" />
                            <br />
                            <asp:Image ID="I_editar" runat="server" CssClass="img-responsive" ImageUrl='<%# Eval("Imagen") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemTemplate>
                          <asp:Image ID="IdInventario" runat="server" CssClass="img-responsive" ImageUrl='<%# Eval("Imagen") %>' Width="100px" />
                            
                        </ItemTemplate>
                        

                      </asp:TemplateField>
                    <asp:TemplateField HeaderText="Referencia" SortExpression="Referencia">
                        <EditItemTemplate>
                            <asp:TextBox ID="tb_referencia" runat="server" Text='<%# Bind("Referencia") %>'  ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_referencia" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lb_referencia" runat="server" Text='<%# Bind("Referencia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Precio" SortExpression="Precio">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Precio") %>'></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="precio invalido Rango 100-1000000" ForeColor="Red" MaximumValue="999999" MinimumValue="100" Type="Integer"></asp:RangeValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Ca_actual" HeaderText="Cantidad Actual" SortExpression="Ca_actual" ReadOnly="true"/>
                    <asp:TemplateField HeaderText="Cantidad Minima" SortExpression="Ca_minima">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Ca_minima") %>'></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Cantidad Invalida Minimo 10 Maximo 500000" MaximumValue="500000" MinimumValue="10" Type="Integer" ControlToValidate="TextBox2" ForeColor="Red"></asp:RangeValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Ca_minima") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marca" SortExpression="Nombre_marca">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DDL_marca" runat="server" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id" SelectedValue='<%# Bind("Id_marca") %>'>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ConsultarMarca" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombre_marca") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Categoria" SortExpression="Nombre_categoria">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DDL_categoria" runat="server" DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" SelectedValue='<%# Bind("Id_categoria") %>'>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ColsultarCategoria2" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre_categoria") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DDL_estado" runat="server" DataSourceID="ODS_Estado" DataTextField="Estado_item" DataValueField="Id" SelectedValue='<%# Bind("Id_estado") %>'>
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ODS_Estado" runat="server" SelectMethod="ColsultarEstado" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                
            </asp:GridView>
               
                 <asp:ObjectDataSource ID="ODS_Inventario" runat="server" DataObjectTypeName="Utilitarios.UEncapInventario" SelectMethod="ConsultarInventario" TypeName="LogicaNegocio.LAdministrador" UpdateMethod="ActualizarInventario"></asp:ObjectDataSource>
            </div>
            
               <asp:ObjectDataSource ID="ODS_Buscar" runat="server" SelectMethod="BuscarReferencia" TypeName="LogicaNegocio.LAdministrador" DataObjectTypeName="Utilitarios.UEncapInventario" UpdateMethod="ActualizarInventario">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TB_Buscar" Name="a" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            
                <br />
                <asp:Label ID="LB_ruta" runat="server" Text="LB_ruta" Visible="False"></asp:Label>
            
             &nbsp;<br />
            
               <asp:ObjectDataSource ID="ODS_BuscarMarca" runat="server" SelectMethod="BuscarMarca" TypeName="LogicaNegocio.LAdministrador" DataObjectTypeName="Utilitarios.UEncapInventario" UpdateMethod="ActualizarInventario">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_Marca2" Name="marca" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
               <asp:ObjectDataSource ID="ODS_BuscarCategoria" runat="server" SelectMethod="BuscarCategoria" TypeName="LogicaNegocio.LAdministrador" DataObjectTypeName="Utilitarios.UEncapInventario" UpdateMethod="ActualizarInventario">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_Categoria2" Name="categ" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
               <asp:ObjectDataSource ID="ODS_BuscarMarcaCategoria" runat="server" SelectMethod="BuscarMarcaCategoria" TypeName="LogicaNegocio.LAdministrador" DataObjectTypeName="Utilitarios.UEncapInventario" UpdateMethod="ActualizarInventario">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL_Marca2" Name="marca" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="DDL_Categoria2" Name="catego" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            
                <br />
            
             <br />
           </div>
        </div>
    
</asp:Content>

