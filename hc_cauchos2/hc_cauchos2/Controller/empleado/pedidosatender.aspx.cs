using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_empleado_pedidosatender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UEncapUsuario usuarioo = new UEncapUsuario();
        usuarioo = new LLogin().usuarioActivo2((string)Session["correo"]);

        if (usuarioo == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (usuarioo.Rol_id != 2)
        {
            Response.Redirect("../home.aspx");
        }

        int idemple = ((UEncapUsuario)Session["Valido"]).User_id;
        Session["empleid"] = idemple;
        R_pro.Visible = false;
        BTN_confirmar.Visible = false;
        TB_novedad.Visible = false;
        PanelMensaje2.Visible = false;

    }

    protected void R_pedido_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        int id_pedido = int.Parse(((Label)e.Item.FindControl("Id")).Text);
        Session["idpedido"] = id_pedido;
        R_pro.Visible = true;
        R_pro.DataSourceID = "ODS_Productos";
        UEncapPedido estado2 = new UEncapPedido();
        estado2.Id = id_pedido;
        estado2.Estado_pedido = 2;
        new LEmpleado().ActualizarEstadoPedido2(estado2);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se ha comenzado el alistamiento del pedido No.00" + id_pedido.ToString() + "');", true);
        MostrarMensaje2($"Se ha comenzado el alistamiento del pedido No.00" + id_pedido.ToString() + "");
        BTN_confirmar.Visible = true;
        TB_novedad.Visible = true;
        return;

    }

    protected void BTN_confirmar_Click(object sender, EventArgs e)
    {
        UEncapPedido novedad = new UEncapPedido();
        novedad.Id = int.Parse(Session["idpedido"].ToString());
        novedad.Novedad = TB_novedad.Text;
        novedad.Estado_pedido = 3;
        new LEmpleado().ActualizarNovedadPedido(novedad);
        new LEmpleado().ActualizarEstadoPedido3(novedad);

        UEncapUsuario estado = new UEncapUsuario();
        estado.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
        estado.Estado_id = 1;
        new LEmpleado().ActualizarEstadoEmpleado(estado);


        Response.Redirect("pedidosatender.aspx");

    }



    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        PanelMensaje2.Visible = false;
    }

    private void MostrarMensaje2(string mensaje)
    {
        LblMensaje2.Text = mensaje;
        PanelMensaje2.Visible = true;
    }
}