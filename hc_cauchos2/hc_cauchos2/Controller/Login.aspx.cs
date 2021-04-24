using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CREAR LA VALIDACION DE CORREO //
        UEncapUsuario usuario = new UEncapUsuario();

    }

    protected void BTN_ingresar_Click(object sender, EventArgs e)
    {
        //METODO DE LOGIN
        ClientScriptManager cm = this.ClientScript;
        UEncapUsuario usuario = new UEncapUsuario();
        usuario.Correo = TB_correo.Text;
        usuario.Clave = TB_contraseña.Text;
        usuario = new LLogin().login(usuario);

        
        if (usuario == null) {

            MostrarMensaje(" Correo o contraseña equivocados");
            return;
        }
        else
        {
            Session["Correo"] = usuario.Correo;
        }
        
        if (usuario.Estado_id == 1 || usuario.Estado_id == 4)
        {
            Session["Nombre"] = usuario.Nombre + " " + usuario.Apellido;
            Session["Valido"] = usuario;
            usuario.Sesion = (string)Session["Nombre"].ToString();
            new LLogin().actualizarUsuario(usuario);

            switch (usuario.Rol_id)
            {
                case 1:
                    Response.Redirect("administrador/index_admin.aspx");
                    break;
                case 2:
                    Response.Redirect("empleado/index_empleado.aspx");
                    break;
                case 3:
                    Response.Redirect("domiciliario/index_domiciliario.aspx");
                    break;
                case 4:
                    Response.Redirect("usuario/index_usuario.aspx");
                    break;
            }

        }  
        if(usuario.Rol_id == 2)
        {
            MostrarMensaje1($"Su cuenta se encuentra en estado de recuperacion");
            return;
        }else if (usuario.Rol_id == 3)
        {
            MostrarMensaje($"Su cuenta ha sido inhabilitada, comuniquese con el con el administrador");
            return;
        }

      

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

    protected void LButton_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Recuperacion_clave.aspx");
    }

    protected void BTN_si_Click(object sender, EventArgs e)
    {
        UEncapUsuario userb = new UEncapUsuario();
        userb.Correo = TB_correo.Text;
        BTN_si.Visible = false;
        BTN_no.Visible = false;
        string mensaje = new LLogin().Actualizar(userb);
        MostrarMensaje(mensaje);
    }
    protected void BTN_no_Click(object sender, EventArgs e)
    {
        BTN_si.Visible = false;
        BTN_no.Visible = false;
    }


}