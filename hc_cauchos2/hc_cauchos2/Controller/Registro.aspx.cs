using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;
using Datos;


public partial class View_Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
        PanelMensaje2.Visible = false;
    }

    protected void BTN_registrar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        UEncapUsuario verificarCorreo = new UEncapUsuario();
        verificarCorreo.Correo = TB_correo.Text;
        //creo objeto para verificar identificacion
        UEncapUsuario verificarIdentificacion = new UEncapUsuario();
        verificarIdentificacion.Identificacion = TB_identificacion.Text;
        //envio secuencias de verificacion
        bool veriCorreo = new LLogin().verificarCorreo(verificarCorreo);
        bool veriIdentificacion = new LLogin().verificarIdentificacion(verificarIdentificacion);

        if (veriCorreo == true && veriIdentificacion == true)
        {
            //traigo valores de los texbox
            UEncapUsuario User = new UEncapUsuario();
            User.Nombre = TB_nombres.Text;
            User.Apellido = TB_apellidos.Text;
            User.Correo = TB_correo.Text;
            User.Clave = TB_contraseña.Text;
            User.Fecha_nacimiento = DateTime.Parse(TB_fecha_nacimiento.Text);
            int actual = DateTime.Now.Year;
            if ((actual - (int)User.Fecha_nacimiento.Year) < 18)
            {
                //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Debe ser mayor de edad para poderse registrar' );</script>");
                //return;
                MostrarMensaje1($"Para registrarse debe ser mayor de edad");
                return;
            }
            if ((actual - (int)User.Fecha_nacimiento.Year) > 80)
            {
                //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'No aceptamos edades mayores a 80' );</script>");
                //return;
                MostrarMensaje1($"No aceptamos personas mayores de 80 años");
                return;
            }

            User.Identificacion = TB_identificacion.Text;
            User.Rol_id = 4;
            User.Estado_id = 1;
            //apunto a metodo de insert 
            new LLogin().insertarUsuario(User);
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El usuario se ha registrado satisfactoriamente' );</script>");
            MostrarMensaje2($"El usuario se ha registrado satisfactoriamente");
            TB_nombres.Text = "";
            TB_apellidos.Text = "";
            TB_correo.Text = "";
            TB_contraseña.Text = "";
            TB_confirmar_contra.Text = "";
            TB_identificacion.Text = "";
            TB_fecha_nacimiento.Text = "";
            return;

        }

        if (veriCorreo != true)
        {
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo ya se encuentra registrado' );</script>");
            //return;
            MostrarMensaje($"El correo ya se encuentra registrado");
            return;
        }
        if (veriIdentificacion != true)
        {
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'La identificacion ya se encuentra registrada' );</script>");
            //return;
            MostrarMensaje($"La identificacion ya se encuentra registrada");
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

    private void MostrarMensaje2(string mensaje)
    {
        LblMensaje2.Text = mensaje;
        PanelMensaje2.Visible = true;
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
}