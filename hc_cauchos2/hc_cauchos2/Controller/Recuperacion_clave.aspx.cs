using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Utilitarios;
using LogicaNegocio;
using System.Text.Json.Serialization;

public partial class View_Recuperacion_clave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void BTN_Recuperar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        UEncapUsuario usuario = new UEncapUsuario();
        

        usuario = new LLogin().verificarCorreoRecuperacion(TB_CorreoRecuperar.Text);

        if (usuario != null)
        {
            //encriptacion de token
            usuario.Clave = "";
            usuario.Estado_id = 2;
            usuario.Token = new LLogin().encriptar(JsonConvert.SerializeObject(usuario.Token));
            usuario.Tiempo_token = DateTime.Now.AddDays(1);

            new Correo().enviarCorreo(usuario.Correo, usuario.Token, "");
            new LLogin().actualizarUsuario(usuario);
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Token enviado por favor verifique el correo');window.location=\" ../login.aspx\"</script>");


        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Correo no encontrado por favor verifique' );</script>");
            return;
        }
    }

    protected void BTN_inicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}