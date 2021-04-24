<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/TiempoProductosCarrito.aspx.cs" Inherits="View_administrador_TiempoProductosCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h1 class="text-center"><strong>PARAMETRIZACIONES</strong></h1>
    <div class="container">
        <div class=" row">
            <br /><br /><br />
            <div class="col-lg-4">
                <div class="card text-center" style="width: 18rem;">
                  <img class="" src="../../ima/reloj.png" alt="Card image cap">
                  <div class="card-body">
                    <h1 class="card-title">Tiempo productos en carrito</h1>
                    <p class="card-text">Aqui podra parametrizar la duracion de los productos en carrito para confirmacion de factura (SERA MEDIDO EN MINUTOS)</p>
                      <asp:TextBox ID="TB_cantidad_T" runat="server" placeholder="Minutos" TextMode="Number" Width="121px" CssClass="form-control"></asp:TextBox>
                      <asp:RangeValidator ID="RV_cantidad" runat="server" ErrorMessage="*" ControlToValidate="TB_cantidad_T" MinimumValue="1" Type="Integer" MaximumValue="180"></asp:RangeValidator>
                      <br />
                      <asp:ImageButton ID="BTN_confirmar_T" runat="server" ImageUrl="~/ima/marca.png" OnClick="BTN_confirmar_T_Click" />
                  </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card text-center" style="width: 18rem;">
                  <div class="card-body">
                    <h1 class="card-title">Tiempo productos en carrito</h1>
                    <p class="card-text">Aqui podra parametrizar la duracion de los productos en carrito para confirmacion de factura (SERA MEDIDO EN MINUTOS)</p>
                      <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/ima/marca.png" />
                  </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card text-center" style="width: 18rem;">
                  <div class="card-body">
                    <h1 class="card-title">Tiempo productos en carrito</h1>
                    <p class="card-text">Aqui podra parametrizar la duracion de los productos en carrito para confirmacion (SERA MEDIDO EN MINUTOS)</p>
                      <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/ima/marca.png" />
                  </div>
                </div>
            </div>

        </div>
    </div>
              
</asp:Content>

