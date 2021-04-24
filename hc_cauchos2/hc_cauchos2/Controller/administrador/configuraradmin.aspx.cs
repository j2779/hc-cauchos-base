using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Utilitarios;

public partial class View_administrador_configuraradmin : System.Web.UI.Page
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

        //inicio componentes de edit componentes como invisibles
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
        TB_editarPass.Visible = false;
        BTN_editarPass.Visible = false;
        BTN_cancelar.Visible = false;
        BTN_cancelar2.Visible = false;


        UEncapUsuario usu = new UEncapUsuario();
        usu = new LLogin().usuarioActivo((string)Session["Nombre"]);
        LB_nombre.Text = usu.Nombre;
        LB_apellido.Text = usu.Apellido;
        LB_correo.Text = usu.Correo;
        LB_contraseña.Text = usu.Clave;

    }

    protected void BTN_editarCorreo_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        UEncapUsuario verificar = new UEncapUsuario();
        verificar.Correo = TB_editCorreo.Text;
        //apunto a verificar el correo #si es null no existe#
        bool respuesta = new LLogin().verificarCorreo(verificar);

        if(respuesta == true)
        {
            //actualizo datos de usuario CORREO
            UEncapUsuario nuevo = new UEncapUsuario();
            nuevo = new LLogin().usuarioActivo((string)Session["Nombre"]);
            nuevo.Correo = TB_editCorreo.Text;
            new LLogin().actualizarUsuario(nuevo);
            TB_editCorreo.Text = "";
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //desoculto elementos para poder editar
        TB_editCorreo.Visible = true;
        BTN_editarCorreo.Visible = true;
        BTN_cancelar.Visible = true;
    }

    protected void BTN_editarPass_Click(object sender, EventArgs e)
    {
        //actualizo datos de usuario CORREO
        UEncapUsuario nuevo = new UEncapUsuario();
        nuevo = new LLogin().usuarioActivo((string)Session["Nombre"]);
        nuevo.Clave = TB_editarPass.Text;
        new LLogin().actualizarUsuario(nuevo);
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