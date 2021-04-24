using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Utilitarios;

public partial class View_administrador_Mision_Vision_Objetivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UEncapUsuario User = new UEncapUsuario();
        User = new LLogin().usuarioActivo2((string)Session["Correo"]);
        if (User == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (User.Rol_id != 1)
        {
            Response.Redirect("../home.aspx");
        }

        EncapMision mision = new EncapMision();
        EncapVision vision = new EncapVision();
        EncapObjetivo objetivo = new EncapObjetivo();

        mision.Id = 1;
        vision.Id = 1;
        objetivo.Id = 1;

        mision = new LAdministrador().ObtenerMision(mision);
        vision = new LAdministrador().ObtenerVision(vision);
        objetivo = new LAdministrador().ObtenerObjetivo(objetivo);

        LB_Mision.Text = mision.Mision;
        LB_Vision.Text = vision.Vision;
        LB_Objetivo.Text = objetivo.Objetivo;

        TB_EditMision.Visible = false;
        BTN_ActualizarM.Visible = false;
        BTN_cancerlarM.Visible = false;
        TB_EditVision.Visible = false;
        BTN_ActualizarV.Visible = false;
        BTN_CancelarV.Visible = false;
        TB_EditObjetivo.Visible = false;
        BTN_ActializarO.Visible = false;
        BTN_CancelarO.Visible = false;

    }

    protected void BTN_ActualizarM_Click(object sender, EventArgs e)
    {
        EncapMision mision = new EncapMision();
        mision.Mision = TB_EditMision.Text;
        new LAdministrador().ActualizarMision(mision);
        TB_EditMision.Text = "";
        Response.Redirect("Mision_Vision_Objetivo.aspx");
    }

    protected void BTN_cancerlarM_Click(object sender, EventArgs e)
    {
        TB_EditMision.Text = "";
        TB_EditMision.Visible = false;
        BTN_ActualizarM.Visible = false;
        BTN_cancerlarM.Visible = false;
    }

    protected void BTN_ActualizarV_Click(object sender, EventArgs e)
    {
        EncapVision vision = new EncapVision();
        vision.Vision = TB_EditVision.Text;
        new LAdministrador().ActualizarVision(vision);
        TB_EditVision.Text = "";
        Response.Redirect("Mision_Vision_Objetivo.aspx");
    }

    protected void BTN_CancelarV_Click(object sender, EventArgs e)
    {
        TB_EditVision.Text = "";
        TB_EditVision.Visible = false;
        BTN_ActualizarV.Visible = false;
        BTN_CancelarV.Visible = false;
    }

    protected void BTN_ActializarO_Click(object sender, EventArgs e)
    {
        EncapObjetivo objetivo = new EncapObjetivo();
        objetivo.Objetivo = TB_EditObjetivo.Text;
        new LAdministrador().ActualizarObjetivo(objetivo);
        TB_EditObjetivo.Text = "";
        Response.Redirect("Mision_Vision_Objetivo.aspx");
    }

    protected void BTN_CancelarO_Click(object sender, EventArgs e)
    {
        TB_EditVision.Text = "";
        TB_EditObjetivo.Visible = false;
        BTN_ActializarO.Visible = false;
        BTN_CancelarO.Visible = false;
    }

    protected void IB_Objetivo_Click(object sender, ImageClickEventArgs e)
    {
        TB_EditObjetivo.Visible = true;
        BTN_ActializarO.Visible = true;
        BTN_CancelarO.Visible = true;
    }

    protected void IB_Vision_Click(object sender, ImageClickEventArgs e)
    {
        TB_EditVision.Visible = true;
        BTN_ActualizarV.Visible = true;
        BTN_CancelarV.Visible = true;
    }

    protected void IB_mision_Click(object sender, ImageClickEventArgs e)
    {
        TB_EditMision.Visible = true;
        BTN_ActualizarM.Visible = true;
        BTN_cancerlarM.Visible = true;
    }
}