using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Utilitarios;

public partial class View_administrador_insertarEmpleados : System.Web.UI.Page
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

    protected void BTN_registrar_empleado_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        UEncapUsuario verificar = new UEncapUsuario();
        verificar.Correo = TB_correo.Text;
        verificar.Identificacion = TB_identificacion.Text;
        //apunto a verificar el correo #si es null no existe#
        bool verificaCorreo = new LLogin().verificarCorreo(verificar);
        bool verificaIdentificacion = new LLogin().verificarIdentificacion(verificar);

        if (verificaCorreo == false && verificaIdentificacion == false)
        {
            //traigo valores de los texbox
            UEncapUsuario Emple = new UEncapUsuario();
            Emple.Nombre = TB_nombres.Text;
            Emple.Apellido = TB_apellidos.Text;
            Emple.Correo = TB_correo.Text;
            Emple.Clave = TB_contraseña.Text;
            Emple.Fecha_nacimiento = DateTime.Parse(TB_fecha_nacimiento.Text);
            Emple.Last_modify = DateTime.Now;
            Emple.Sesion = Session["Nombre"].ToString();

            int actual = DateTime.Now.Year;
            if ((actual - (int)Emple.Fecha_nacimiento.Year) < 18)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'Debe ser mayor de edad para poderse registrar' );</script>");
                return;
            }
            Emple.Identificacion = TB_identificacion.Text;
            Emple.Rol_id = int.Parse(DDL_tipo_empleado.SelectedValue);
            Emple.Estado_id = 1;

            //apunto a metodo de insert 
            new LLogin().insertarEmpleado(Emple);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El usuario se ha registrado satisfactoriamente' );</script>");

            //resect para componentes
            TB_nombres.Text = "";
            TB_apellidos.Text = "";
            TB_correo.Text = "";
            TB_contraseña.Text = "";
            TB_fecha_nacimiento.Text = "";
            TB_identificacion.Text = "";
            TB_confirmar_contra.Text = "";
        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo o identificacion ya se encuentran registrados' );</script>");
            return;
        }

    }

}