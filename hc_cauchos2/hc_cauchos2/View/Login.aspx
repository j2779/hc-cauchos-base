<%@ Page Title="" Language="C#" MasterPageFile="~/View/Principal.master" AutoEventWireup="true" CodeFile="~/Controller/Login.aspx.cs" Inherits="View_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" >
    <style> 
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
      -webkit-box-shadow: 0 10px 30px 0 rgba(233, 95, 95, 0.4);
      box-shadow: 0 10px 30px 0 rgba(95,186,233,0.4);
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

    #TB_correo{
        border: 1px dotted #999
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
                                <div class="form-group">
                                    <img src="../ima/cauchosicono.png" id="icon" alt="User Icon" /><br />
                                     <br />
                                     <asp:TextBox ID="TB_correo" runat="server"  class="form-control d-inline text-center rounded-pill" placeholder="Correo" TextMode="Email" Width="85%" ></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Login" ControlToValidate="TB_correo" ErrorMessage="*"></asp:RequiredFieldValidator>
                                     <br />
                                    <br />
                                     <asp:TextBox ID="TB_contraseña" runat="server"  class="form-control d-inline text-center rounded-pill" placeholder="Contraseña" TextMode="Password" Width="85%" MaxLength="16"></asp:TextBox>                    
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Login" ControlToValidate="TB_contraseña" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>  
                                 <div>                     
                                      <asp:Button ID="BTN_ingresar" runat="server" ValidationGroup="Login" Text="Ingresar" class="fadeIn fourth" OnClick="BTN_ingresar_Click" />
                                     <br />
                                     
                                        <asp:Panel runat="server" ID="PanelMensaje" Visible="false" CssClass="alert alert-danger shadow" role="alert">
                                              <strong>
                                                  <asp:Label ID="LblMensaje" runat="server" />
                                              </strong>
                                              <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="B_cerrar_mensaje" />
                                        </asp:Panel>


                                      <asp:Panel runat="server" ID="PanelMensaje1" Visible="false" CssClass="alert alert-warning shadow" role="alert">
                                              <strong>
                                                  <asp:Label ID="LblMensaje1" runat="server" />
                                              </strong>
                                              <asp:LinkButton Text="<span aria-hidden='true'>&times;</span>" runat="server" CssClass="close" ID="B_cerrar_mensaje1" />
                                        </asp:Panel>
                                 </div>
                                <asp:Button ID="BTN_si" runat="server" Text="Si"  Width="118px"/>
                                 <asp:Button ID="BTN_no" runat="server" Text="No"  Width="139px"/>
                           
                            <div id="formFooter">
                                <asp:LinkButton ID="LButton_Recuperar" runat="server" >Olvido Su Contraseña?</asp:LinkButton>
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
    <br />
</asp:Content>

