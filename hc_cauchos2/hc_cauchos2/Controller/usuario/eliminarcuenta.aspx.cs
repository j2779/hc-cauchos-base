using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_usuario_eliminarcuenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        UEncapUsuario usuario = new UEncapUsuario();
        usuario = new LLogin().usuarioActivo2((string)Session["correo"]);

        if (usuario == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (usuario.Rol_id != 4)
        {
            Response.Redirect("../home.aspx");
        }


        

        BTN_si.Visible = false;
        BTN_no.Visible = false;
        LB_Seguro.Visible = false;
    }

    protected void IB_eliminar_Click(object sender, ImageClickEventArgs e)
    {
        BTN_si.Visible = true;
        BTN_no.Visible = true;
        LB_Seguro.Visible = true;
    }

    protected void BTN_si_Click(object sender, EventArgs e)
    {
        int iduser = ((UEncapUsuario)Session["Valido"]).User_id;
        UEncapUsuario eliminar = new UEncapUsuario();
        eliminar.User_id = iduser;
        new LUsuario().EliminarUsuario(eliminar);
        //new DAOUser().EliminarCuenta(eliminar);
        Session["Valido"] = null;
        Response.Redirect("../home.aspx");
    }

    protected void BTN_no_Click(object sender, EventArgs e)
    {
        BTN_si.Visible = false;
        BTN_no.Visible = false;
        LB_Seguro.Visible = false;
    }
}