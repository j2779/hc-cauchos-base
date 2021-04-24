using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Utilitarios;


public partial class View_Actualizacion_clave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        if (Request.QueryString.Count > 0)
        {
             UEncapUsuario  user = new LLogin().BuscarToken(Request.QueryString[0] == null ? "" : Request.QueryString[0]);


            if (user == null)
            {

                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido genere uno nuevamente');window.location=\" ../login.aspx\"</script>");

            }
            else if (user.Tiempo_token < DateTime.Now)
            {

                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\" ../login.aspx\"</script>");

            }
            else
                Session["user_id"] = user;
        }

        else
            Response.Redirect("../login.aspx");
    }

    protected void BTN_Recuperar_Click(object sender, EventArgs e)
    {
        UEncapUsuario usuario = new UEncapUsuario();

        usuario.Clave = TB_Repetir.Text;
        usuario.Estado_id = 1;
        usuario.Tiempo_token = null;
        usuario.Token = null;
        usuario.Sesion = usuario.Nombre + "" + usuario.Apellido;

        new LLogin().actualizarUsuario(usuario);
        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Su contraseña ha sido actualizada');window.location=\" ../login.aspx\"</script>");
    }
}