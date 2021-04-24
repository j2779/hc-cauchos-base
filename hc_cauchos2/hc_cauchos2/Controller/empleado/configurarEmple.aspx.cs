using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_empleado_configurarEmple : System.Web.UI.Page
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

        //inicio componentes de edit componentes como invisibles
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
        TB_editarPass.Visible = false;
        BTN_editarPass.Visible = false;
        BTN_cancelar.Visible = false;
        BTN_cancelar2.Visible = false;

        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
        PanelMensaje2.Visible = false;



        //creo objeto de encap usuario 
        UEncapUsuario usuario = new UEncapUsuario();
        //envio sesion de usuario activo y valido existencia
        usuario = new LEmpleado().usuarioactivo((string)Session["Nombre"]);
        LB_nombre.Text = usuario.Nombre;
        LB_apellido.Text = usuario.Apellido;
        LB_correo.Text = usuario.Correo;
        LB_contraseña.Text = usuario.Clave;
    }


    protected void BTN_editarCorreo_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        UEncapUsuario verificar = new UEncapUsuario();
        verificar.Correo = TB_editCorreo.Text;
        //apunto a verificar el correo #si es null no existe#
        verificar = new LEmpleado().verificarCorreo(verificar);

        // valido si el correo existe
        if (verificar == null)
        {
            //actualizo datos de usuario CORREO
            UEncapUsuario nuevo = new UEncapUsuario();
            nuevo = new LEmpleado().usuarioactivo((string)Session["Nombre"]);
            nuevo.Correo = TB_editCorreo.Text;
            new LEmpleado().actualizaruser(nuevo);
            TB_editCorreo.Text = "";

        }
        else
        {
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo ya se encuentra registrado' );</script>");
            MostrarMensaje1($"El correo ya se encuentra registrado");
            TB_editCorreo.Text = "";
            return;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //mostrar elementos para poder editar
        TB_editCorreo.Visible = true;
        BTN_editarCorreo.Visible = true;
        BTN_cancelar.Visible = true;
    }

    protected void BTN_cancelar_Click(object sender, EventArgs e)
    {
        //ocultar elementos por cancelacion
        TB_editCorreo.Visible = false;
        BTN_editarCorreo.Visible = false;
    }

    protected void BTN_editarPass_Click(object sender, EventArgs e)
    {
        //actualizar datos de usuario 
        UEncapUsuario nuevo = new UEncapUsuario();
        nuevo = new LEmpleado().usuarioactivo((string)Session["Nombre"]);
        nuevo.Clave = TB_editarPass.Text;
        new LEmpleado().actualizaruser(nuevo);
        MostrarMensaje2($"Contraseña cambiada con exito!!");
        TB_editarPass.Text = "";
        return;
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

    protected void B_cerrar_mensaje1_Click(object sender, EventArgs e)
    {
        PanelMensaje.Visible = false;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        PanelMensaje1.Visible = false;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        PanelMensaje2.Visible = false;
    }

    private void MostrarMensaje(string mensaje)
    {
        LblMensaje.Text = mensaje;
        PanelMensaje.Visible = true;
    }

    private void MostrarMensaje1(string mensaje)
    {
        LblMensaje1.Text = mensaje;
        PanelMensaje1.Visible = true;
    }

    private void MostrarMensaje2(string mensaje)
    {
        LblMensaje2.Text = mensaje;
        PanelMensaje2.Visible = true;
    }
}