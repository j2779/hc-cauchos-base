<%@ Page Title="" Language="C#" MasterPageFile="~/View/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controller/empleado/facturar.aspx.cs" Inherits="View_empleado_facturar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <h1 class="text-center text-primary"><strong>PRODUCTOS
        <br />
        <small>Agrega tus productos y cantidades</small></strong></h1>
    <asp:ObjectDataSource ID="ODS_catalogo0" runat="server" SelectMethod="consultarinventario" TypeName="LogicaNegocio.LEmpleado"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoCategoria" runat="server" SelectMethod="consultarinventariocategoria" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DD_Categoria" Name="categoria" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoMarca" runat="server" SelectMethod="consultarinventariomarca" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoCombinado" runat="server" SelectMethod="consultarinventariocombinado" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DD_Categoria" Name="categoria" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecio" runat="server" SelectMethod="consultarinventarioprecio" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecioCategoria" runat="server" SelectMethod="consultarinventariopreciocategoria" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DD_Categoria" Name="categoria" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecioMarca" runat="server" SelectMethod="consultarinventariopreciomarca" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_catalogoPrecioCombinado" runat="server" SelectMethod="consultarinventariopreciocombinado" TypeName="LogicaNegocio.LEmpleado">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDL_Precio" Name="valores" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DD_Marca" Name="marca" PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter ControlID="DD_Categoria" Name="categoria" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="consultarcategoria" TypeName="LogicaNegocio.LEmpleado"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="consultarmarca" TypeName="LogicaNegocio.LEmpleado"></asp:ObjectDataSource>
    <br />
    <br />
    <div class="col-sm-12">
        <div class="form-inline justify-content-center">
            <div class="form-group">
                <asp:DropDownList ID="DD_Categoria" runat="server" class="form-control" DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="234px">
                </asp:DropDownList>
                <asp:DropDownList ID="DD_Marca" runat="server" Class="form-control" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id" Width="234px">
                </asp:DropDownList>
                <asp:DropDownList ID="DDL_Precio" runat="server" Class="form-control" Width="234px">
                    <asp:ListItem Value="0 , 0">Ordenar Precio</asp:ListItem>
                    <asp:ListItem Value="0 , 10000">Menores a 10000</asp:ListItem>
                    <asp:ListItem Value="10000 , 50000">10000 - 50000</asp:ListItem>
                    <asp:ListItem Value="50000 , 100000">50000 - 100000</asp:ListItem>
                    <asp:ListItem Value="100000 , 200000">100000 - 200000</asp:ListItem>
                    <asp:ListItem Value="200000 , 500000">200000 - 500000</asp:ListItem>
                    <asp:ListItem Value="500000 , 6000000">Mayores a 500000</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Btn_Buscar" runat="server" Class="btn btn-primary" OnClick="Btn_Buscar_Click" Text="Buscar" />
                <asp:Button ID="Btn_Todos" runat="server" Class="btn btn-primary" OnClick="Btn_Todos_Click" Text="Todos" />
                &lt;/&gt;
            </div>
        </div>
    </div>
    <br />
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
    <asp:ObjectDataSource ID="ODS_catalogo" runat="server" SelectMethod="consultarinventario" TypeName="LogicaNegocio.LEmpleado"></asp:ObjectDataSource>
    <div class="row ">
        <br />
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ODS_catalogo" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-2 col-sm-6 col-xs-8 mb-3">
                    <div id="productos" class="card shadow text-block" style=" width:165px; height:510px;">
                        <asp:Image ID="Image1" runat="server" class="card-img-top" Height="30%" ImageAlign="TextTop" ImageUrl='<%# Eval("Imagen") %>' width="100%" />
                        <div class="card-body">
                            <h4 id="titulo" class="card-title text-center"><strong>
                                <asp:Label ID="TituloLabel" runat="server" Text='<%# Eval("Titulo") %>' />
                                </strong></h4>
                            <strong>Referencia:</strong>
                            <asp:Label ID="ReferenciaLabel" runat="server" class="card-text" Text='<%# Eval("Referencia") %>' />
                                <br />
                                <strong>Precio:</strong>
                            <asp:Label ID="PrecioLabel" runat="server" class="card-text" Text='<%# Eval("Precio") %>' />
                                <br />
                                <strong>Stock:</strong>
                            <asp:Label ID="Ca_actualLabel" runat="server" class="card-text" Text='<%# Eval("Ca_actual") %>' />
                                <br />
                                <strong>Marca:</strong>
                            <asp:Label ID="NombremarcaLabel" runat="server" class="card-text" Text='<%# Eval("Nombre_marca") %>' />
                                <br />
                                <strong>Categoria:</strong>
                            <asp:Label ID="Nombre_categoriaLabel" runat="server" class="card-text" Text='<%# Eval("Nombre_categoria") %>' />
                                <br />
                                <strong>Cantidad:</strong>
                            <asp:TextBox ID="TB_cantidad" runat="server" Class="card-text" CssClass="text-black" MaxLength="4" TextMode="Number" Width="25%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFV_cantidad" runat="server" ControlToValidate="TB_cantidad" EnableClientScript="True" ErrorMessage="*" ValidationGroup='<%# Eval("Id") %>'></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;
                            <asp:RangeValidator ID="RV_cantidad" runat="server" ControlToValidate="TB_cantidad" ErrorMessage="valor invalido" MaximumValue="1000" MinimumValue="1" Type="Integer" ValidationGroup='<%# Eval("Id") %>'></asp:RangeValidator>
                            <asp:ImageButton ID="BTNI_carritoAdd" runat="server" class="center-block bottom-left" CommandArgument='<%# Eval("Id") %>' ImageUrl="~/ima/newproduct.png" ValidationGroup='<%# Eval("Id") %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

