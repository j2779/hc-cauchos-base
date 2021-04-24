using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_empleado_Registrarcliente : System.Web.UI.Page
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
    }
    protected void BTN_registrar_cliente_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //creo objeto para verificar correo 
        UEncapUsuario verificar = new UEncapUsuario();
        verificar.Correo = TB_correo.Text;
        //apunto a verificar el correo #si es null no existe#
        verificar = new LEmpleado().verificarCorreo(verificar);
        UEncapUsuario verificarIdentificacion = new UEncapUsuario();
        verificarIdentificacion.Identificacion = TB_identificacion.Text;
        verificarIdentificacion = new LEmpleado().verificaridentificacion(verificarIdentificacion);

        if (verificar == null && verificarIdentificacion == null)
        {
            //traigo valores de los texbox
            UEncapUsuario clien= new UEncapUsuario();
            clien.Nombre = TB_nombres.Text;
            clien.Apellido = TB_apellidos.Text;
            clien.Correo = TB_correo.Text;
            clien.Fecha_nacimiento = DateTime.Parse(TB_fecha_nacimiento.Text);
            clien.Identificacion = TB_identificacion.Text;
            clien.Rol_id = 4;
            clien.Estado_id = 2;
            clien.Last_modify = DateTime.Now;
            clien.Sesion = Session["Nombre"].ToString();

            //apunto a metodo de insert 
            new LEmpleado().InsertarCliente(clien);
            new LEmpleado().InsertarEmpleado(clien);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El cliente se ha registrado satisfactoriamente' );</script>");

            //resect para componentes
            TB_nombres.Text = "";
            TB_apellidos.Text = "";
            TB_correo.Text = "";
            TB_fecha_nacimiento.Text = "";
            TB_identificacion.Text = "";
        }
        else
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ( 'El correo o contraseña ya se encuentran registrados' );</script>");
            return;
        }
    }

    protected void BTN_Regresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ventas.aspx");
    }
}