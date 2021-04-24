<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/AgregarInventario.aspx.cs" Inherits="View_administrador_AgregarInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
    <h1 class="text-center text-primary"><strong>Agregar Producto</strong></h1>
         <div class="row">
               <div class="col-md-4 col-md-offset-4">
                   <div class="form-group">
                       <br /> <br />
                       Imagen:
                       <asp:FileUpload id="FU_Archivo" runat="server" CssClass="form-control" ValidationGroup="vali"></asp:FileUpload>
                       <br />
                       <asp:TextBox ID="TB_referencia" runat="server" CssClass="form-control" placeholder="Referencia Item" MaxLength="25"  ></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TB_referencia" runat="server" ErrorMessage="*" ValidationGroup="vali" ForeColor="Red"></asp:RequiredFieldValidator>
                       <asp:TextBox ID="TB_Titulo" runat="server" CssClass="form-control" placeholder="Titulo Item" MaxLength ="25" ></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_Titulo" ErrorMessage="*" ValidationGroup="vali" ForeColor="Red"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_Titulo" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="vali" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="TB_Precio" runat="server" CssClass="form-control" TextMode="Number" placeholder="Precio " MaxLength="6"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TB_Precio" runat="server" ErrorMessage="*" ValidationGroup="vali"></asp:RequiredFieldValidator>
                       <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Valor invalido" ControlToValidate="TB_Precio" MaximumValue="4000000" MinimumValue="100" ValidationGroup="vali" Type="Double" ForeColor="Red"></asp:RangeValidator>
                       <asp:TextBox ID="TB_Minima" runat="server" CssClass="form-control" TextMode="Number" placeholder="Cantidad Minima" MaxLength="5"></asp:TextBox>
                       <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cantidad invalida" ControlToValidate="TB_Minima" MaximumValue="1999999999" MinimumValue="0" ValidationGroup="vali" Type="Double" ForeColor="Red"></asp:RangeValidator>
                       <br />

                  <div class="col-sm-12">
                     <div class="form-inline justify-content-center">
                        <div class="form-group">
                            <asp:DropDownList ID="DDL_Marca" runat="server" class="form-control" DataSourceID="ODS_Marca" DataTextField="Marca" DataValueField="Id"  Width="222px"></asp:DropDownList>
                             <asp:DropDownList ID="DDL_Categoria" runat="server" class="form-control"  DataSourceID="ODS_Categoria" DataTextField="Categoria" DataValueField="Id" Width="222px"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue= "0" ControlToValidate="DDL_Categoria" ErrorMessage="*" ValidationGroup="vali" ForeColor="Red"></asp:RequiredFieldValidator>          
                        </div>
                    </div>
                  </div>  

                  <div class="col-sm-12">
                     <div class="form-inline justify-content-center">
                        <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" InitialValue= "0"  ControlToValidate="DDL_Marca" ValidationGroup="vali" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                    </div>
                  </div>  
                       
                        

                  <asp:ObjectDataSource ID="ODS_Marca" runat="server" SelectMethod="ConsultarMarca" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
                       <br />
                       <asp:ObjectDataSource ID="ODS_Categoria" runat="server" SelectMethod="ConsultarCategoria" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
                       <asp:Button ID ="BTN_subir" runat="server" Text="Almacenar" class=" btn btn-primary center-block"  ValidationGroup="vali" OnClick="BTN_subir_Click" />
                       <asp:Panel runat="server" ID="PanelMensaje" Visible="false" CssClass="alert alert-danger shadow" role="alert">
	                        <strong>
	                        <asp:Label ID="LblMensaje" runat="server" />
	                        </strong>
	                        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="B_cerrar_mensaje1" OnClick="B_cerrar_mensaje1_Click"  />
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
	                        <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton2" OnClick="LinkButton2_Click"  />
                        </asp:Panel>
                       <br />
                   </div>   
               </div> 
         </div>
</asp:Content>

