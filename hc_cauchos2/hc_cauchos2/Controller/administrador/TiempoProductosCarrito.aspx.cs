using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Utilitarios;

public partial class View_administrador_TiempoProductosCarrito : System.Web.UI.Page
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

    protected void BTN_confirmar_T_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        UEncapParametros tiempocarrito = new UEncapParametros();
        tiempocarrito.Id = 1;
        tiempocarrito.Nombre = "tiempocarrito";
        tiempocarrito.Valor = TB_cantidad_T.Text;
        new LAdministrador().ActualizarTiempoCarrito(tiempocarrito);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Se ha cambiado el parametro correctamente.');</script>");
    }
}