<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/insertarEmpleados.aspx.cs" Inherits="View_administrador_insertarEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
    <h1 class="text-center text-primary"><strong>Agregar Empleados</strong></h1>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                            <br />     
                <div class="form-group">
                            <asp:TextBox ID="TB_nombres" runat="server" class="form-control rounded-pill" placeholder="nombres"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nombres" ErrorMessage="*"></asp:RequiredFieldValidator>
                 
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_nombres" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="Registro" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:TextBox ID="TB_apellidos" runat="server" class="form-control rounded-pill" placeholder="apellido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Registro" ControlToValidate="TB_apellidos" ErrorMessage="*"></asp:RequiredFieldValidator>
                    
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_apellidos" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="Registro" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>
                            
                            <asp:TextBox ID="TB_correo" runat="server" class="form-control rounded-pill" placeholder="correo"  TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Registro" ControlToValidate="TB_correo" ErrorMessage="*"></asp:RequiredFieldValidator>
                    
                            <asp:TextBox ID="TB_contraseña" runat="server" class="form-control rounded-pill" placeholder="contraseña"></asp:TextBox>     
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Registro" ControlToValidate="TB_contraseña" ErrorMessage="*"></asp:RequiredFieldValidator>
                          
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Se requiere entre 8 - 16 caracteres tanto letras,numeros,mayusculas y minusculas" ControlToValidate="TB_contraseña" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" ForeColor="Red" Font-Size="X-Small"></asp:RegularExpressionValidator>
                            
                            <asp:TextBox ID="TB_confirmar_contra" runat="server" class="form-control rounded-pill" placeholder="confirmar contraseña"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Registro" ControlToValidate="TB_confirmar_contra" ErrorMessage="*"></asp:RequiredFieldValidator>
                    
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Contraseña diferente" ControlToCompare="TB_confirmar_contra" ControlToValidate="TB_contraseña" ValidationGroup="Registro" ForeColor="Red"></asp:CompareValidator>

                            <asp:TextBox ID="TB_fecha_nacimiento" runat="server" class="form-control rounded-pill" placeholder="fecha nacimiento" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Registro" ControlToValidate="TB_fecha_nacimiento" ErrorMessage="*"></asp:RequiredFieldValidator>
                          
                            <asp:TextBox ID="TB_identificacion" runat="server" class="form-control rounded-pill" placeholder="identificacion"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Registro" ControlToValidate="TB_identificacion" ErrorMessage="*"></asp:RequiredFieldValidator>
                         
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cedula invalida" ControlToValidate="TB_identificacion" MaximumValue="1999999999" MinimumValue="10000000" ValidationGroup="Registro" Type="Double" ForeColor="Red"></asp:RangeValidator>        

                            <asp:DropDownList ID="DDL_tipo_empleado" runat="server" class="form-control rounded-pill" ValidationGroup="Registro">
                                <asp:ListItem Value="2">empleado</asp:ListItem>
                                <asp:ListItem Value="3">domiciliario</asp:ListItem>
                            </asp:DropDownList>
                            <br />                      
                            <asp:Button ID="BTN_registrar_empleado" runat="server" Text="Registrar" class="btn btn-primary center-block" ValidationGroup="Registro" OnClick="BTN_registrar_empleado_Click" />
                </div>                        
             </div>                                   
       </div>       
</asp:Content>

