using Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_administrador_ConsultarInventario : System.Web.UI.Page
{
    protected string aux;
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
        LB_ruta.Visible = false;
        Label4.Visible = false;



        DDL_Categoria2.Enabled = false;
        DDL_Marca2.Enabled = false;
        BT_Inabilitar.Visible = false;

        ValidarControles();
    }

    protected void BT_Inabilitar_Click(object sender, EventArgs e)
    {
        InabilitarDDLS();
        BT_Inabilitar.Visible = false;
    }

    protected void BT_Filtrar_Click(object sender, EventArgs e)
    {
        HabilitarDDLS();
    }

    protected void BT_Buscar_Click(object sender, EventArgs e)
    {
        if (TB_Buscar.Text != "")
        {
            GV_inventario.DataSourceID = "ODS_Buscar";
            InabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex != 0 && DDL_Marca2.SelectedIndex != 0)
        {
            GV_inventario.DataSourceID = "ODS_BuscarMarcaCategoria";
            HabilitarDDLS();
        }
        else
        if (DDL_Marca2.SelectedIndex != 0)
        {

            GV_inventario.DataSourceID = "ODS_BuscarMarca";
            HabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex != 0)
        {
            GV_inventario.DataSourceID = "ODS_BuscarCategoria";
            HabilitarDDLS();

        }
        else
        if (DDL_Categoria2.SelectedIndex == 0 || DDL_Marca2.SelectedIndex == 0)
        {
            InabilitarDDLS();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GV_inventario.DataSourceID = "ODS_Inventario";

        if (TB_Buscar.Text != "")
        {

            InabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex != 0 || DDL_Marca2.SelectedIndex != 0)
        {

            HabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex == 0 || DDL_Marca2.SelectedIndex == 0)
        {
            InabilitarDDLS();
        }
    }

    protected void GV_inventario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {


            //string referencia = e.Row.Cells[2].Text.ToString();//obtener valor de la celda

            //obtener datakeyname
            int id = Convert.ToInt32(GV_inventario.DataKeys[e.Row.RowIndex].Values[0].ToString());

            //obtener valor de la celda convertido en teamplatefield
            var referencia = e.Row.FindControl("lb_referencia") as Label;
            EncapInventario inventario = new EncapInventario();
            
            inventario = new DAOAdmin().BuscarId(inventario, id);

            if (inventario != null)
            {
                var image = e.Row.FindControl("IdInventario") as Image;

                String imgUrl64 = (inventario.Imagen);
                image.ImageUrl = imgUrl64;
            }

            

    
        }*/
    }

    protected void GV_inventario_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //indice de la fila
        GridViewRow row = GV_inventario.Rows[e.RowIndex];
        ClientScriptManager cm = this.ClientScript;

        //traer valor textbox
        var tb_referencia = row.FindControl("tb_referencia") as TextBox;

        FileUpload fu_imagen = (FileUpload)row.FindControl("fu_imagen");



        int id = Convert.ToInt32(GV_inventario.DataKeys[e.RowIndex].Values[0].ToString());
        //EncapInventario inventario = new EncapInventario();//



        string urlExistente = ((Image)row.FindControl("I_editar")).ImageUrl;
        string nombreArchivo = System.IO.Path.GetFileName(fu_imagen.PostedFile.FileName);
        string Ruta = "~\\Inventario\\" + nombreArchivo;

        if (nombreArchivo == "")
        {
            e.NewValues["Imagen"] = urlExistente;
        }
        else
        if ((nombreArchivo != ""))
        {

            string extension = System.IO.Path.GetExtension(fu_imagen.PostedFile.FileName);

            string saveLocationAdmin = HttpContext.Current.Server.MapPath("~\\Inventario\\") + nombreArchivo;

            if (!(extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png") || extension.Equals(".gif")))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('tipo de archivo no valido ' );</script>");
                e.Cancel = true;
            }
            //verificar existencia de un arhivo con el mismo nombre
            if (System.IO.File.Exists(saveLocationAdmin))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Imagen Existente' );</script>");
                e.Cancel = true;
            }
            try
            {
                if (urlExistente != "")
                {
                    File.Delete(Server.MapPath(urlExistente));
                }
                fu_imagen.PostedFile.SaveAs(saveLocationAdmin);
                e.NewValues["Imagen"] = Ruta;
            }
            catch (Exception exc)

            {

                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Error' );</script>");
                return;
            }

            ValidarControles();

        }

        UEncapInventario refe = new UEncapInventario();
        refe.Referencia = tb_referencia.Text;

        bool consulta = new LAdministrador().consultarReferencia(refe);
        
        //var db = new Mapeo();
        //var consulta = (from x in db.inventario where (x.Referencia == tb_referencia.Text) select x.Referencia).Count();
       

        //referencia Existente
        if (consulta == true)
        {
            //si el valorexistente es el mismo
            if (Label4.Text == tb_referencia.Text)
            {
                //agrego valor que habia antes 
                e.NewValues["Referencia"] = Label4.Text;


            }
            else
            {

                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Referencia Existente' );</script>");
                e.Cancel = true;
            }
        }
    }

    protected void GV_inventario_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = GV_inventario.Rows[e.NewEditIndex];
        int id = Convert.ToInt32(GV_inventario.DataKeys[e.NewEditIndex].Values[0].ToString());

        var lb_referencia = row.FindControl("lb_referencia") as Label;

        //asigno el valor que tenia antes de editarlo

        aux = lb_referencia.Text;
        Label4.Text = aux;
        Label4.Visible = true;
    }

    protected void GV_inventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // GV_inventario.DataSourceID = "ODS_Inventario";
        // GV_inventario.PageIndex = e.NewPageIndex;
        // GV_inventario.DataBind();

    }

    public void ValidarControles()
    {

        if (TB_Buscar.Text != "")
        {

            InabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex != 0 || DDL_Marca2.SelectedIndex != 0)
        {

            HabilitarDDLS();
        }
        else
        if (DDL_Categoria2.SelectedIndex == 0 || DDL_Marca2.SelectedIndex == 0)
        {
            InabilitarDDLS();
        }

    }

    private void HabilitarDDLS()
    {
        TB_Buscar.Text = "";
        BT_Filtrar.Visible = false;
        BT_Inabilitar.Visible = true;
        TB_Buscar.Enabled = false;
        DDL_Categoria2.Enabled = true;
        DDL_Marca2.Enabled = true;
    }
    private void InabilitarDDLS()
    {
        DDL_Categoria2.SelectedIndex = 0;
        DDL_Marca2.SelectedIndex = 0;
        BT_Filtrar.Visible = true;
        BT_Inabilitar.Visible = false;
        TB_Buscar.Enabled = true;
        DDL_Categoria2.Enabled = false;
        DDL_Marca2.Enabled = false;
    }

}