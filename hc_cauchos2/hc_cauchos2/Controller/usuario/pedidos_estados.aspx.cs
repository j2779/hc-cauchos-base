using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_usuario_pedidos_estados : System.Web.UI.Page
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
        //obtengo el id del domiciliario y lo almaceno en una session
        int idusu = ((UEncapUsuario)Session["Valido"]).User_id;
        Session["clienid"] = idusu;
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var btn_factura = e.Item.FindControl("Btn_factura") as Button;
        var lb_idfac = e.Item.FindControl("Id") as Label;
        Session["Id_fac"] = Convert.ToInt32(lb_idfac.Text);
        //Response.Redirect("Factura.aspx");
    }
}