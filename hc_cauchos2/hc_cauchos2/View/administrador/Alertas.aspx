<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/Alertas.aspx.cs" Inherits="View_administrador_Alertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ObjectDataSource ID="ODS_Alertas" runat="server" SelectMethod="ConsultarAlertas" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>

   <link href="../../bootstrap/css/Alertas.css" rel="stylesheet" type="text/css" />
    <h1 class="text-center text-primary"><strong>PRODUCTOS EN ESTADO CRITICO</strong></h1>

        <asp:Repeater ID="RepeaterAlerta" runat="server" DataSourceID="ODS_Alertas" OnItemDataBound="RepeaterAlerta_ItemDataBound" OnItemCommand="RepeaterAlerta_ItemCommand"  >          
            <ItemTemplate>
                 <div class="card text-center bg-primary fa-border border-dark mb-5 col-sm-6">
                  <div class="card-header">
                      <h2 class="text-center">Cantidad Critica</h2>  
                  </div>
                  <div class="card-body text-black">
                         <h3 class="card-title"><%# Eval("Titulo") %></h3>
                        <p class="card-text">El producto con referencia <%# Eval("Referencia") %> se encuentra menor a su cantidad minima <%# Eval("Ca_minima") %> </p>
                        <p class="card-text">Cantidad Actual:<%# Eval("Ca_actual") %></p>
                      <!--
                        <asp:Button ID="Button1" runat="server" Text="Abastecer" CssClass="btn btn-primary" />  
                      -->
                  </div>
                </div>                   
            </ItemTemplate>            
       </asp:Repeater>
</asp:Content>

