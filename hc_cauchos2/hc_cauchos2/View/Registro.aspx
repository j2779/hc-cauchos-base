<%@ Page Title="" Language="C#" MasterPageFile="~/View/Principal.master" AutoEventWireup="true" CodeFile="~/Controller/Registro.aspx.cs" Inherits="View_Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
            html {

    }

    body {

    }

    a {
      color: #92badd;
      display:inline-block;
      text-decoration: none;
      font-weight: 400;
    }

    h2 {

    }



    /* STRUCTURE */

    .wrapper {
      display: flex;
      align-items: center;
      flex-direction: column; 
      justify-content: center;
      width: 100%;
      min-height: 100%;
      padding: 20px;
    }

    #formContent {
      -webkit-border-radius: 10px 10px 10px 10px;
      border-radius: 10px 10px 10px 10px;
      background: #fff;
      padding: 30px;
      /*width: 130%;*/
      max-width: 450px;
      position: relative;
      padding: 0px;
      -webkit-box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
      box-shadow: 0 30px 60px 0 rgba(0,0,0,0.3);
      text-align: center;
    }

    #formFooter {
      background-color: #f6f6f6;
      border-top: 1px solid #dce8f1;
      padding: 25px;
      text-align: center;
      -webkit-border-radius: 0 0 10px 10px;
      border-radius: 0 0 10px 10px;
    }



    /* TABS */

    h2.inactive {
      color: #cccccc;
    }

    h2.active {
      color: #0d0d0d;
      border-bottom: 2px solid #5fbae9;
    }



    /* FORM TYPOGRAPHY*/

    input[type=button], input[type=submit], input[type=reset]  {
      background-color: #ed5656;
      border: none;
      color: white;
      padding: 15px 80px;
      text-align: center;
      text-decoration: none;
      display: inline-block;
      text-transform: uppercase;
      font-size: 13px;
      -webkit-box-shadow: 0 10px 30px 0 rgba(95,186,233,0.4);
      box-shadow: 0 10px 30px 0 rgba(233, 95, 95, 0.4);
      -webkit-border-radius: 5px 5px 5px 5px;
      border-radius: 5px 5px 5px 5px;
      margin: 5px 20px 40px 20px;
      -webkit-transition: all 0.3s ease-in-out;
      -moz-transition: all 0.3s ease-in-out;
      -ms-transition: all 0.3s ease-in-out;
      -o-transition: all 0.3s ease-in-out;
      transition: all 0.3s ease-in-out;
    }

    input[type=button]:hover, input[type=submit]:hover, input[type=reset]:hover  {
      background-color: #770e18;
    }

    input[type=button]:active, input[type=submit]:active, input[type=reset]:active  {
      -moz-transform: scale(0.95);
      -webkit-transform: scale(0.95);
      -o-transform: scale(0.95);
      -ms-transform: scale(0.95);
      transform: scale(0.95);
    }

    input[type=text] {
      background-color: #f6f6f6;
      border: none;
      color: #0d0d0d;
      padding: 15px 32px;
      text-align: center;
      text-decoration: none;
      display: inline-block;
      font-size: 16px;
      margin: 5px;
      width: 85%;
      border: 2px solid #f6f6f6;
      -webkit-transition: all 0.5s ease-in-out;
      -moz-transition: all 0.5s ease-in-out;
      -ms-transition: all 0.5s ease-in-out;
      -o-transition: all 0.5s ease-in-out;
      transition: all 0.5s ease-in-out;
      -webkit-border-radius: 5px 5px 5px 5px;
      border-radius: 5px 5px 5px 5px;
    }

    input[type=text]:focus {
      background-color: #fff;
      border-bottom: 2px solid #5fbae9;
    }

    input[type=text]:placeholder {
      color: #cccccc;
    }



    /* ANIMATIONS */

    /* Simple CSS3 Fade-in-down Animation */
    .fadeInDown {
      -webkit-animation-name: fadeInDown;
      animation-name: fadeInDown;
      -webkit-animation-duration: 1s;
      animation-duration: 1s;
      -webkit-animation-fill-mode: both;
      animation-fill-mode: both;
    }

    @-webkit-keyframes fadeInDown {
      0% {
        opacity: 0;
        -webkit-transform: translate3d(0, -100%, 0);
        transform: translate3d(0, -100%, 0);
      }
      100% {
        opacity: 1;
        -webkit-transform: none;
        transform: none;
      }
    }

    @keyframes fadeInDown {
      0% {
        opacity: 0;
        -webkit-transform: translate3d(0, -100%, 0);
        transform: translate3d(0, -100%, 0);
      }
      100% {
        opacity: 1;
        -webkit-transform: none;
        transform: none;
      }
    }

    /* Simple CSS3 Fade-in Animation */
    @-webkit-keyframes fadeIn { from { opacity:0; } to { opacity:1; } }
    @-moz-keyframes fadeIn { from { opacity:0; } to { opacity:1; } }
    @keyframes fadeIn { from { opacity:0; } to { opacity:1; } }

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

    .fadeIn.first {
      -webkit-animation-delay: 0.4s;
      -moz-animation-delay: 0.4s;
      animation-delay: 0.4s;
    }

    .fadeIn.second {
      -webkit-animation-delay: 0.6s;
      -moz-animation-delay: 0.6s;
      animation-delay: 0.6s;
    }

    .fadeIn.third {
      -webkit-animation-delay: 0.8s;
      -moz-animation-delay: 0.8s;
      animation-delay: 0.8s;
    }

    .fadeIn.fourth {
      -webkit-animation-delay: 1s;
      -moz-animation-delay: 1s;
      animation-delay: 1s;
    }

    /* Simple CSS3 Fade-in Animation */
    .underlineHover:after {
      display: block;
      left: 0;
      bottom: -10px;
      width: 0;
      height: 2px;
      background-color: #56baed;
      content: "";
      transition: width 0.2s;
    }

    .underlineHover:hover {
      color: #0d0d0d;
    }

    .underlineHover:hover:after{
      width: 100%;
    }



    /* OTHERS */

    *:focus {
        outline: none;
    } 

    #icon {
      width:60%;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <br />    
    <div class="container">
        <div class="row">

            <div class="col-2">
            </div>

            <div class="col-8"> 
                <div class="wrapper fadeInDown">
                    <div id="formContent">
                        <div class="fadeIn first">
                            <img src="../ima/registrohc (2).png" id="icon" alt="User Icon" />
                            <div class="form-group">
                                 <asp:TextBox ID="TB_nombres" runat="server" class="form-control rounded-pill" placeholder="nombres" MaxLength="23" ValidationGroup="Registro"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Registro" ControlToValidate="TB_nombres" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_nombres" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="Registro" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>

                                <asp:TextBox ID="TB_apellidos" runat="server" class="form-control rounded-pill" placeholder="apellido" MaxLength="30" ValidationGroup="Registro"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Registro" ControlToValidate="TB_apellidos" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo se permiten letras y minimo 3" ControlToValidate="TB_apellidos" ValidationExpression="^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$"  ValidationGroup="Registro" Font-Underline="True" ForeColor="Red"></asp:RegularExpressionValidator>

                                <asp:TextBox ID="TB_correo" runat="server" class="form-control d-inline text-center rounded-pill" placeholder="correo"  TextMode="Email" Width="85%" ValidationGroup="Registro" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Registro" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                <asp:TextBox ID="TB_contraseña" runat="server" class="form-control d-inline text-center rounded-pill" placeholder="contraseña" MaxLength="16" ValidationGroup="Registro" Width="85%" TextMode="Password"></asp:TextBox>     
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Registro" ControlToValidate="TB_contraseña" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Se requiere entre 8 - 16 caracteres tanto letras,numeros,mayusculas y minusculas" ControlToValidate="TB_contraseña" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" ForeColor="Red" Font-Size="X-Small"></asp:RegularExpressionValidator>

                                <asp:TextBox ID="TB_confirmar_contra" runat="server" class="form-control d-inline text-center rounded-pill" placeholder="confirmar contraseña" MaxLength="16" ValidationGroup="Registro" Width="85%" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Registro" ControlToValidate="TB_confirmar_contra" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Contraseña diferente" ControlToCompare="TB_confirmar_contra" ControlToValidate="TB_contraseña" ValidationGroup="Registro" ForeColor="Red"></asp:CompareValidator>

                                <asp:TextBox ID="TB_fecha_nacimiento" runat="server" class="form-control d-inline text-center rounded-pill" placeholder="fecha nacimiento" TextMode="Date" Width="85%" ValidationGroup="Registro"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Registro" ControlToValidate="TB_fecha_nacimiento" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                <asp:TextBox ID="TB_identificacion" runat="server" class="form-control d-inline text-center rounded-pill" Width="85%" placeholder="identificacion" MaxLength="11" TextMode="Number" ValidationGroup="Registro"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Registro" ControlToValidate="TB_identificacion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>    
                                <br />
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Cedula invalida" ControlToValidate="TB_identificacion" MaximumValue="1999999999" MinimumValue="10000000" ValidationGroup="Registro" Type="Double" ForeColor="Red"></asp:RangeValidator>
                                <br />                               
                                <asp:Button ID="BTN_registrar" runat="server" Text="Registrar" class="fadeIn fourth"  ValidationGroup="Registro" OnClick="BTN_registrar_Click"/> 
                                
                                <div style="" class="center-block text-center">
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
	                                    <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton1" OnClick="LinkButton1_Click"  />
                                    </asp:Panel>

                                    <asp:Panel runat="server" ID="PanelMensaje2" Visible="false" CssClass="alert alert-success shadow" role="alert">
	                                    <strong>
	                                    <asp:Label ID="LblMensaje2" runat="server" />
	                                    </strong>
	                                    <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="LinkButton2" OnClick="LinkButton2_Click"  />
                                    </asp:Panel>
                                </div>                           
                            </div>      
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-4">
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>

