using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using LogicaNegocio;
using Utilitarios;

public partial class View_administrador_AgregarInventario : System.Web.UI.Page
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



    protected void BTN_subir_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        int auxprecio = int.Parse(TB_Precio.Text);
        int aux_minimo = int.Parse(TB_Minima.Text);

        if (auxprecio <= 0 || aux_minimo <= 0)
        {

            //MostrarMensaje($"No se permiten datos negativos");
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('NO SE PERMITE DATOS NEGATIVOS' );</script>");
            return;//Devolverse
        }


        //Propiedades del archivo a subirs


        string nombreArchivo = System.IO.Path.GetFileName(FU_Archivo.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Archivo.PostedFile.FileName);

        string saveLocationAdmin = HttpContext.Current.Server.MapPath("~\\Inventario\\") + nombreArchivo;
        string Ruta = "~\\Inventario\\" + nombreArchivo;

        //validar Aechivo de tipo imagen
        if (!(extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png") || extension.Equals(".gif")))
        {
            //MostrarMensaje($"Tipo de archivo no valido");
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('tipo de archivo no valido ' );</script>");
            return;//Devolverse
        }


        //verificar existencia de un arhivo con el mismo nombre
        if (System.IO.File.Exists(saveLocationAdmin))
        {
            //MostrarMensaje1($"Imagen existente");
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Imagen Existente' );</script>");
            return;
        }
        //Validaciones 
        var db = new Mapeo();
        var consulta1 = (from x in db.inventario where x.Referencia.Equals(TB_referencia.Text) select x.Referencia).Count();
        UEncapInventario referencia = new UEncapInventario();
        referencia.Referencia = TB_referencia.Text;
        bool consultRef = new LAdministrador().consultarReferencia(referencia);
        //si referencia ya existe

        if (consultRef == true)
        {
            //MostrarMensaje1($"La referencia ya existe");
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('La Referencia Ya Existe' );</script>");
            return;


        }

        else
        {
            try
            {





                //Guardar Archivo local
                FU_Archivo.PostedFile.SaveAs(saveLocationAdmin);


                UEncapInventario invent = new UEncapInventario();


                invent.Imagen = Ruta;
                invent.Titulo = TB_Titulo.Text;
                invent.Referencia = TB_referencia.Text;
                invent.Precio = int.Parse(TB_Precio.Text);

                invent.Ca_minima = int.Parse(TB_Minima.Text);
                invent.Id_marca = int.Parse(DDL_Marca.Text);
                invent.Id_categoria = int.Parse(DDL_Categoria.Text);
                invent.Id_estado = 1;
                invent.Ca_actual = 0;
                invent.Last_modify = DateTime.Now;
                invent.Session = Session["Nombre"].ToString();

                new LAdministrador().insertarItem(invent);

                //MostrarMensaje2($"Item registrado correctamente");
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Item registrado correctamente' );</script>");
            }
            catch (Exception exc)
            {
                //MostrarMensaje($"Error");
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Error' );</script>");
                return;
            }
        }

        TB_Titulo.Text = "";
        TB_referencia.Text = "";

        TB_Minima.Text = "";
        TB_Precio.Text = "";


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