using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_domiciliario_configurarDomici : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UEncapUsuario usuarioo = new UEncapUsuario();
        usuarioo = new LLogin().usuarioActivo2((string)Session["correo"]);

        if (usuarioo == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (usuarioo.Rol_id != 3)
        {
            Response.Redirect("../home.aspx");
        }

        //inicio componentes de edit componentes como invisibles
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
        TB_editarPass.Visible = false;
        BTN_editarPass.Visible = false;
        BTN_cancelar.Visible = false;
        BTN_cancelar2.Visible = false;


        //creo objeto de encap usuario 
        UEncapUsuario usuario = new UEncapUsuario();
        //envio sesion de usuario activo y valffido existencia
        usuario = new LDomiciliario().usuarioactivo((string)Session["Nombre"]);
        LB_nombre.Text = usuario.Nombre;
        LB_apellido.Text = usuario.Apellido;
        LB_correo.Text = usuario.Correo;
        LB_contraseña.Text = usuario.Clave;
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //desocultar elementos para poder editar
        TB_editCorreo.Visible = true;
        BTN_editarCorreo.Visible = true;
        BTN_cancelar.Visible = true;
    }

    protected void BTN_editarCorreo_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        UEncapUsuario usuario = new UEncapUsuario();
        usuario.Correo = TB_editCorreo.Text;
        usuario = new LDomiciliario().verificarCorreo(usuario);

        
        if (usuario == null)
        {
            //actualizo datos de usuario CORREO
            UEncapUsuario user = new UEncapUsuario();
            user = new  LDomiciliario().usuarioactivo((string)Session["Nombre"]);
            user.Correo = TB_editCorreo.Text;
            new LDomiciliario().actualizaruser(user);
            TB_editCorreo.Text = " ";

        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo ya se encuentra registrado' );</script>");
            TB_editCorreo.Text = "";
            return;
        }
    }

    protected void BTN_cancelar_Click(object sender, EventArgs e)
    {
        //oculto elementos por cancelacion
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
    }

    protected void BTN_editarPass_Click(object sender, EventArgs e)
    {
        //actualizo datos de usuario CORREO
        UEncapUsuario nuevo = new UEncapUsuario();
        nuevo = new LDomiciliario().usuarioactivo((string)Session["Nombre"]);
        nuevo.Clave = TB_editarPass.Text;
        new LDomiciliario().actualizaruser(nuevo);
        TB_editarPass.Text = "";
    }

    protected void BTN_cancelar2_Click(object sender, EventArgs e)
    {
        TB_editarPass.Visible = false;
        BTN_editarPass.Visible = false;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        TB_editarPass.Visible = true;
        BTN_editarPass.Visible = true;
        BTN_cancelar2.Visible = true;
    }

}