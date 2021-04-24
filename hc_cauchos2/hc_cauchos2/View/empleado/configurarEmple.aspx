<%@ Page Title="" Language="C#" MasterPageFile="~/View/empleado/empleado.master" AutoEventWireup="true" CodeFile="~/Controller/empleado/configurarEmple.aspx.cs" Inherits="View_empleado_configurarEmple" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1 class="text-center text-primary">&nbsp;</h1>
        <h1 class="text-center text-primary"><strong>Mi cuenta</strong></h1>
        <div align="center">
            <asp:Image ID="Image1" runat="server" align="center" ImageUrl="~/ima/configurar.png" />
        </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <br />
                <br />
                <div class="form-group">
                    Nombre:
                    <asp:Label ID="LB_nombre" runat="server" class="form-control"></asp:Label>
                    Apellido:
                    <asp:Label ID="LB_apellido" runat="server" class="form-control" Text="Label"></asp:Label>
                    Correo:
                    <asp:Label ID="LB_correo" runat="server" class="form-control" Text="Label"></asp:Label>
                    <asp:TextBox ID="TB_editCorreo" runat="server" class="form-control" placeholder="Ingrese el nuevo correo" TextMode="Email" ValidationGroup="grupocorreo"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_editCorreo" ErrorMessage="*" ValidationGroup="grupocorreo"></asp:RequiredFieldValidator>
                    <asp:Button ID="BTN_editarCorreo" runat="server" class="btn btn-primary" OnClick="BTN_editarCorreo_Click" Text="Cambiar" ValidationGroup="grupocorreo" />
                    <asp:Button ID="BTN_cancelar" runat="server" class="btn btn-primary" OnClick="BTN_cancelar_Click" Text="Cancelar" />
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/ima/engranaje.png" OnClick="ImageButton1_Click" Width="16px" />
                    <br />
                    Contraseña:
                    <asp:Label ID="LB_contraseña" runat="server" class="form-control" Text="Label"></asp:Label>
                    <asp:TextBox ID="TB_editarPass" runat="server" class="form-control" placeholder="Ingrese la nueva contraseña" ValidationGroup="grupopass"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_editarPass" ErrorMessage="*" ValidationGroup="grupopass"></asp:RequiredFieldValidator>
                    <asp:Button ID="BTN_editarPass" runat="server" class="btn btn-primary" OnClick="BTN_editarPass_Click" Text="Cambiar" ValidationGroup="grupopass" />
                    <asp:Button ID="BTN_cancelar2" runat="server" Class="btn btn-primary" OnClick="BTN_cancelar2_Click" Text="Cancelar" />
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/ima/engranaje.png" OnClick="ImageButton2_Click" />
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_editarPass" ErrorMessage="Se requiere entre 8 - 16 caracteres tanto letras,numeros,mayusculas y minusculas" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" ValidationGroup="grupopass"></asp:RegularExpressionValidator>
                </div>
                <div>
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
            </div>
        </div>
</asp:Content>

