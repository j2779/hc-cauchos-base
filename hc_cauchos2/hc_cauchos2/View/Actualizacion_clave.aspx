<%@ Page Title="" Language="C#" MasterPageFile="~/View/Principal.master" AutoEventWireup="true" CodeFile="~/Controller/Actualizacion_clave.aspx.cs" Inherits="View_Actualizacion_clave" %>

<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .fadeInDown {
      -webkit-animation-name: fadeInDown;
      animation-name: fadeInDown;
      -webkit-animation-duration: 1s;
      animation-duration: 1s;
      -webkit-animation-fill-mode: both;
      animation-fill-mode: both;
    }

    .wrapper {
      display: flex;
      align-items: center;
      flex-direction: column; 
      justify-content: center;
      width: 100%;
      min-height: 100%;
      padding: 20px;
    }

    .fadeIn.first {
      -webkit-animation-delay: 0.4s;
      -moz-animation-delay: 0.4s;
      animation-delay: 0.4s;
    }

    .fadeIn {
      opacity:0;
      -webkit-animation:fadeIn ease-in 1;
      -moz-animation:fadeIn ease-in 1;
      animation:fadeIn ease-in 1;

      -webkit-animation-fill-mode:forwards;
      -moz-animation-fill-mode:forwards;
      animation-fill-mode:forwards;

      -webkit-animation-duration:1s;
      -moz-animation-duration:1s;
      animation-duration:1s;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-4">
                <br />
                <br />
                <div class="wrapper fadeInDown">
                    <div id="formContent">
                    <!-- Tabs Titles -->
                    <!-- Icon -->
                        <div class="fadeIn first">
                            <h2>Recuperar contraseña</h2>
                            <br />
                            <br />
                            <asp:TextBox ID="TB_Contraseña" runat="server" class="form-control" Height="23px" placeholder="Nueva Contraseña" TextMode="Password" Width="144px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_Contraseña" ErrorMessage="*" ValidationGroup="Validar"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TB_Repetir" runat="server" class="form-control" Height="24px" placeholder="Confirmar Contraseña" TextMode="Password" Width="144px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_Repetir" ErrorMessage="*" ValidationGroup="Validar"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TB_Contraseña" ControlToValidate="TB_Repetir" ErrorMessage="Las Contraseñas no coinciden"></asp:CompareValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_Contraseña" ErrorMessage="la contraseña debe tener entre 8 - 10 caracteres tanto letra, numeros y caracteres especiales" ValidationExpression="(?=^.{8,10}$)(?=.*\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&amp;*()_+}{':;'?/&gt;.&lt;,])(?!.*\s).*$"></asp:RegularExpressionValidator>
                        </div>
                    <!-- Login Form -->
                        <div>
                            <asp:Button ID="BTN_Cambiar" runat="server" class="fadeIn fourth"  style="height: 52px" Text="Cambiar" ValidationGroup="Validar" />
                        </div>
                    <!-- Remind Passowrd -->
                        <div id="formFooter">
                            &nbsp;</div>
                    </div>
                </div>
            </div>
            <div class="col-4">
            </div>
        </div>
    </div>
</asp:Content>

