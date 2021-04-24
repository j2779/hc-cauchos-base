<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/Mision_Vision_Objetivo.aspx.cs" Inherits="View_administrador_Mision_Vision_Objetivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            
    <h1 class="text-center text-primary"><strong>Mision/Vision/Objetivo <br />
        <small>Modifique dando click en las llaves</small></strong></h1>
    <br />
        <div class="container">
            <div class="row">
                 <div class="col-4">
                     <div class="form-group">
                         <h2><strong>MISION</strong></h2>
                         <h3><asp:Label ID="LB_Mision" runat="server" Text="Label"></asp:Label></h3>   
                         <asp:ImageButton ID="IB_mision" runat="server" ImageUrl="~/Inventario/engranaje.png" OnClick="IB_mision_Click" style="height: 16px" />
                         <asp:TextBox ID="TB_EditMision" runat="server" TextMode="MultiLine" placeholder="Agrege la nueva MISION de la empresa"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TB_EditMision" ValidationGroup="mision"></asp:RequiredFieldValidator>
                         <br />
                         <asp:Button ID="BTN_ActualizarM" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BTN_ActualizarM_Click" ValidationGroup="mision"/>
                         <asp:Button ID="BTN_cancerlarM" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="BTN_cancerlarM_Click" />
                         <br />
                    </div>    
                 </div>
                 <div class="col-4">
                      <div class="form-group">
                          <h2><strong>VISION</strong></h2>
                          <h3><asp:Label ID="LB_Vision" runat="server" Text="Label"></asp:Label></h3>
                          <asp:ImageButton ID="IB_Vision" runat="server" ImageUrl="~/Inventario/engranaje.png" OnClick="IB_Vision_Click" />
                          <asp:TextBox ID="TB_EditVision" runat="server" TextMode="MultiLine" placeholder="Agrege la nueva VISION de la empresa"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="TB_EditVision" ValidationGroup="vision"></asp:RequiredFieldValidator>
                          <br />
                          <asp:Button ID="BTN_ActualizarV" runat="server" Text="Actualizar" class="btn btn-primary" OnClick="BTN_ActualizarV_Click"  ValidationGroup="vision"/>
                          <asp:Button ID="BTN_CancelarV" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="BTN_CancelarV_Click" />
                          <br />
                      </div>
                 </div>
                 <div class="col-4">
                      <div class="form-group">
                          <h2><strong>OBJETIVO</strong></h2>
                          <h3><asp:Label ID="LB_Objetivo" runat="server" Text="Label"></asp:Label></h3>  
                          <asp:ImageButton ID="IB_Objetivo" runat="server" ImageUrl="~/Inventario/engranaje.png" OnClick="IB_Objetivo_Click" />
                          <asp:TextBox ID="TB_EditObjetivo" runat="server" TextMode="MultiLine" placeholder="Agrege la nueva VISION de la empresa"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="TB_EditObjetivo" ValidationGroup="objetivo"></asp:RequiredFieldValidator>
                          <br />
                          <asp:Button ID="BTN_ActializarO" runat="server" Text="Actualizar" class="btn btn-primary"  ValidationGroup="objetivo" OnClick="BTN_ActializarO_Click" />
                          <asp:Button ID="BTN_CancelarO" runat="server" Text="Cancelar" class="btn btn-primary" OnClick="BTN_CancelarO_Click" />
                          <br />
                      </div>                  
                 </div>              
            </div>
        </div>
</asp:Content>

