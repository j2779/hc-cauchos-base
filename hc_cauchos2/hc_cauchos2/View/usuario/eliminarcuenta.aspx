<%@ Page Title="" Language="C#" MasterPageFile="~/View/usuario/usuario.master" AutoEventWireup="true" CodeFile="~/Controller/usuario/eliminarcuenta.aspx.cs" Inherits="View_usuario_eliminarcuenta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
    <h1 class="text-center text-primary"><strong>ELIMINAR MI CUENTA</strong></h1>
    <br />
    <asp:ImageButton ID="IB_eliminar" runat="server" ImageUrl="~/ima/perfil.png" class="center-block" OnClick="IB_eliminar_Click" />
    <asp:Label ID="LB_Seguro" runat="server" Text="Label"><h3 class="text-center">¿esta seguro de eliminar por completo su cuenta?</h3></asp:Label> 

        <asp:Button ID="BTN_si" runat="server" Text="Si" class="btn btn-primary center-block" OnClick="BTN_si_Click" Width="20%"/>
        <asp:Button ID="BTN_no" runat="server" Text="No" class="btn btn-primary center-block" OnClick="BTN_no_Click" Width="20%"/>

</asp:Content>

