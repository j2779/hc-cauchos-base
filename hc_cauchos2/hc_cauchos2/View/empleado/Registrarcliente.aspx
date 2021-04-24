<%@ Page Title="" Language="C#" MasterPageFile="~/View/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controller/empleado/Registrarcliente.aspx.cs" Inherits="View_empleado_Registrarcliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <h1 class="text-center"><strong>Agregar Cliente</strong></h1>
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <br />
            <br />
            <div class="form-group">
                <asp:TextBox ID="TB_nombres" runat="server" class="form-control rounded-pill" MaxLength="23" placeholder="nombres"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_nombres" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TB_nombres" ErrorMessage="Solo se permiten letras y minimo 3" Font-Underline="True" ForeColor="Red" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$" ValidationGroup="Registro"></asp:RegularExpressionValidator>
                <asp:TextBox ID="TB_apellidos" runat="server" class="form-control rounded-pill" MaxLength="30" placeholder="apellido"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_apellidos" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TB_apellidos" ErrorMessage="Solo se permiten letras y minimo 3" Font-Underline="True" ForeColor="Red" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$" ValidationGroup="Registro"></asp:RegularExpressionValidator>
                <asp:TextBox ID="TB_correo" runat="server" class="form-control rounded-pill" placeholder="correo" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TB_fecha_nacimiento" runat="server" class="form-control rounded-pill" placeholder="fecha nacimiento" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TB_fecha_nacimiento" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TB_identificacion" runat="server" class="form-control rounded-pill" placeholder="identificacion"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TB_identificacion" ErrorMessage="*" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TB_identificacion" ErrorMessage="Cedula invalida" ForeColor="Red" MaximumValue="1999999999" MinimumValue="10000000" Type="Double"></asp:RangeValidator>
                <br />
                <asp:Button ID="BTN_registrar_cliente" runat="server" class="btn btn-primary" OnClick="BTN_registrar_cliente_Click" Text="Registrar" ValidationGroup="Registro" />
                <asp:Button ID="BTN_Regresar" runat="server" class="btn btn-primary" OnClick="BTN_Regresar_Click" Text="Facturacion" />
            </div>
        </div>
    </div>
</asp:Content>

