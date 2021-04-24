<%@ Page Title="" Language="C#" MasterPageFile="~/View/administrador/Admin.master" AutoEventWireup="true" CodeFile="~/Controller/administrador/HistorialVentas.aspx.cs" Inherits="View_administrador_HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .auto-style10 {
            display: block;
/*height:34px;*/padding: 6px 12px;
/*font-size:14px*/line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 7px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }
        .auto-style15 {
            width: 131px;
        }
        .auto-style16 {
            width: 361px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
      <h1 class="text-center text-primary"><strong>Historial De Ventas <br /><small>Busque por fechas y empleados</small></strong></h1>
    
    <div class="col-sm-12">
        <div class="form-inline text-center">
            <div class="form-group">
                <asp:TextBox ID="TB_Dia" placeholder="Dia (DD)" CssClass="form-control" runat="server" TextMode="Number" Width="150px"></asp:TextBox>
                <asp:TextBox ID="TB_Mes" placeholder="Mes (MM)" CssClass="form-control" runat="server" TextMode="Number" Width="150px"></asp:TextBox>           
                <asp:TextBox ID="TB_Ano" placeholder="Año (YYYY)" CssClass="form-control" runat="server" TextMode="Number" Width="150px" ></asp:TextBox>
            </div>
        </div>
    </div>     
    <div class="col-sm-12">
        <div class="text-center">
            <div class="form-group">
                  <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Dia invalido,Rango entre 1-31" MinimumValue="1" MaximumValue="31" ControlToValidate="TB_Dia" Type="Integer"></asp:RangeValidator>
                  <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Mes invalido,Rango entre 1-12" MinimumValue="1" MaximumValue="12" ControlToValidate="TB_Mes" Type="Integer"></asp:RangeValidator>
                  <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Año invalido,Rango entre 2000-2100" MinimumValue="2000" MaximumValue="2100" ControlToValidate="TB_Ano" Type="Integer"></asp:RangeValidator>
            </div>
        </div>
    </div>
    <div class="">
        <div class="form-inline text-center">
            <div class="form-group">
                <asp:RadioButtonList ID="RBL" runat="server" CssClass="form-group" AutoPostBack="True" OnSelectedIndexChanged="RBL_SelectedIndexChanged" Width="227px">
                       <asp:ListItem Value="0">Activar Empleado</asp:ListItem>
                       <asp:ListItem Value="1">Desactivar Empleado</asp:ListItem>
                  </asp:RadioButtonList>
            </div>
        </div>
    </div>

    <div class="col-sm-11">
        <div class="form-inline text-center">
            <div class="form-group">
                <asp:DropDownList ID="DDL_Empleado" class="form-control" runat="server" DataSourceID="ODS_Empleado" DataTextField="Nombre" DataValueField="User_id"  Enabled="False" Width="128px" Visible="False" OnSelectedIndexChanged="DDL_Empleado_SelectedIndexChanged">
                      <asp:ListItem Value="0"></asp:ListItem>
                   </asp:DropDownList>
                <asp:Button ID="Btn_Buscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="Btn_Buscar_Click" />
                <asp:Button ID="Btn_Todos" CssClass="btn btn-primary" runat="server" Text="Todos" OnClick="Btn_Todos_Click" style="margin-left: 0" />      
           </div>
        </div>
    </div>
                  
     <asp:TextBox ID="TB_Aux" runat="server" TextMode="Number" Visible="False"></asp:TextBox>
     <asp:ObjectDataSource ID="ODS_Empleado" runat="server" SelectMethod="ConsultarEmpleado" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
    <br />
    <br />
    <br />
  <div class="row">
        <div class=" col-lg-12 col-md-offset-0.5">
             <div style="overflow-x: auto;"> 
                 <br />
                     <asp:GridView ID="GV_Historial" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODS_Historial" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="GV_Historial_RowDataBound" ShowFooter="True" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Empleado" HeaderText="Empleado" SortExpression="Empleado" />
                            <asp:BoundField DataField="Fecha_pedido" HeaderText="Fecha " SortExpression="Fecha_pedido" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                      </asp:GridView>
            </div>
        </div>
    </div>

      <asp:ObjectDataSource ID="ODS_Historial" runat="server" SelectMethod="ConsultarVentas" TypeName="LogicaNegocio.LAdministrador"></asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialDia" runat="server" SelectMethod="ConsultarVentasDia" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Dia" Name="Dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialMes" runat="server" SelectMethod="ConsultarVentasMes" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAno" runat="server" SelectMethod="ConsultarVentasAno" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoDia" runat="server" SelectMethod="ConsultarVentasAnoDia" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoMesDia" runat="server" SelectMethod="ConsultarVentasAnoMesDia" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialMesDia" runat="server" SelectMethod="ConsultarVentasMesDia" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialEmpleado" runat="server" SelectMethod="ConsultarVentasAnoMesDiaEmpleado" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="DDL_Empleado" Name="emple" PropertyName="SelectedValue" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_HistorialAnoMesDia0" runat="server" SelectMethod="ConsultarVentasAnoMesDia" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Dia" Name="dia" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <asp:ObjectDataSource ID="ODS_1" runat="server" SelectMethod="ConsultarVentasAnMes" TypeName="LogicaNegocio.LAdministrador">
          <SelectParameters>
              <asp:ControlParameter ControlID="TB_Ano" Name="ano" PropertyName="Text" Type="Int32" />
              <asp:ControlParameter ControlID="TB_Mes" Name="mes" PropertyName="Text" Type="Int32" />
          </SelectParameters>
      </asp:ObjectDataSource>
      <br />
</asp:Content>

