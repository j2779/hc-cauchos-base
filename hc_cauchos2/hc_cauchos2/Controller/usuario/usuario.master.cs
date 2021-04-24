using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_usuario_usuario : System.Web.UI.MasterPage
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


        L_nombreAdmin.Text = ((UEncapUsuario)Session["valido"]).Nombre;
        L_nombreAdmin0.Text = ((UEncapUsuario)Session["valido"]).Nombre;
    }
    protected void BTN_cerrar_Sesion_Click(object sender, EventArgs e)
    {
        /*UEncapUsuario usuario = new UEncapUsuario();
         usuario = new LLogin().usuarioActivo2((string)Session["correo"]);
        usuario.Ip_ = null;
        usuario.Mac_ = null;
        usuario.Sesion = null;
        new LLogin().actualizarUsuario(usuario);*/
        Session["correo"] = null;
        Session["valido"] = -1;
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("../home.aspx");
    }
}

   
       

