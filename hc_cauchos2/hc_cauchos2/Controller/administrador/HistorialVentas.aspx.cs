using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_administrador_HistorialVentas : System.Web.UI.Page
{
    private double Total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UEncapUsuario usuario = new UEncapUsuario();
        usuario = new LLogin().usuarioActivo2((string)Session["correo"]);

        if (usuario == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (usuario.Rol_id != 1)
        {
            Response.Redirect("../home.aspx");
        }
    }

    protected void Btn_Buscar_Click(object sender, EventArgs e)
    {
        if (TB_Dia.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_HistorialDia";

        }
        if (TB_Mes.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_HistorialMes";

        }
        if (TB_Ano.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_HistorialAno";

        }


        if (TB_Dia.Text != "" && TB_Mes.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_HistorialMesDia";

        }

        if (TB_Ano.Text != "" && TB_Dia.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_HistorialAnoDia";
        }
        if (TB_Ano.Text != "" && TB_Mes.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_1";
        }
        if (TB_Ano.Text != "" && TB_Mes.Text != "" && TB_Dia.Text != "")
        {

            GV_Historial.DataSourceID = "ODS_HistorialAnoMesDia";
        }

        if (DDL_Empleado.Visible == true)
        {

            GV_Historial.DataSourceID = "ODS_HistorialEmpleado";

        }
    }

    protected void Btn_Todos_Click(object sender, EventArgs e)
    {
        GV_Historial.DataSourceID = "ODS_Historial";
    }

    protected void RBL_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBL.SelectedIndex == 0)
        {
            DDL_Empleado.Enabled = true;
            DDL_Empleado.Visible = true;

        }
        if (RBL.SelectedIndex == 1)
        {
            DDL_Empleado.Enabled = false;
            DDL_Empleado.Visible = false;
            TB_Aux.Text = "";
            DDL_Empleado.SelectedIndex = 0;
        }
    }

    protected void DDL_Empleado_SelectedIndexChanged(object sender, EventArgs e)
    {
        TB_Aux.Text = DDL_Empleado.SelectedValue;
    }

    protected void GV_Historial_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}