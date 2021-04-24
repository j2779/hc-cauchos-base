using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_domiciliario_entregas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UEncapUsuario usuario = new UEncapUsuario();
        usuario = new LLogin().usuarioActivo2((string)Session["correo"]);

        if (usuario == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (usuario.Rol_id != 3)
        {
            Response.Redirect("../home.aspx");
        }

        //obtengo el id del domiciliario y lo almaceno en una session
        int id_domiciliario = ((UEncapUsuario)Session["Valido"]).User_id;
        Session["domiciliario_id"] = id_domiciliario;

    }

    protected void R_pedido_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;
        UEncapPedido entrega = new UEncapPedido();
        entrega.Id = int.Parse(((Label)e.Item.FindControl("Id")).Text);
        entrega.Fecha_pedido_fin = DateTime.Now;
        //otorgo a pedido fecha de finalizacion y update de estado
        new LDomiciliario().actualizarnovedad(entrega);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se ha realizado la entrega satisfactoria del pedido No.00');", true);
        Response.Redirect("entregas.aspx");


    }
}