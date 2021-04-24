using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_administrador_HistorialPedido : System.Web.UI.Page
{
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

    protected void GV_Pedidos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Btn_todos_Click(object sender, EventArgs e)
    {
        GV_Pedidos.DataSourceID = "ODS_Pedidos";
    }

    protected void DDL_Estado_SelectedIndexChanged(object sender, EventArgs e)
    {
        GV_Pedidos.DataSourceID = "ODS_PedidosEstado";
    }
    

    protected void GV_Pedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
}