using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Utilitarios;

public partial class View_usuario_catalogoUsuario : System.Web.UI.Page
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



        //obtengo el usuario que esta en session en el momento 
        int iduser = ((UEncapUsuario)Session["Valido"]).User_id;
        Session["userid"] = iduser;
        //numero de cantidad en el carrito 
        LB_cantidad.Text = new LUsuario().ObtenerCantidadCarritoUser(iduser).ToString();
        PanelMensaje1.Visible = false;

    }

    protected void Btn_Todos_Click(object sender, EventArgs e)
    {
        //reinicio de filtros y repeater
        Repeater1.DataSourceID = "ODS_catalogo";
        DDL_Precio.SelectedIndex = 0;
        DD_Marca.SelectedIndex = 0;
        DD_Categoria.SelectedIndex = 0;
    }

    protected void Btn_Buscar_Click(object sender, EventArgs e)
    {
        //filtros Marca y categoria
        if (DD_Categoria.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoCategoria";

        }
        if (DD_Marca.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoMarca";
        }
        if (DD_Marca.SelectedIndex != 0 && DD_Categoria.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoCombinado";
        }
        //validaciones Precio marca y categoria
        if (DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecio";
        }
        if (DD_Categoria.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioCategoria";
        }
        if (DD_Marca.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioMarca";
        }
        if (DD_Categoria.SelectedIndex != 0 && DD_Marca.SelectedIndex != 0 && DDL_Precio.SelectedIndex != 0)
        {
            Repeater1.DataSourceID = "ODS_catalogoPrecioCombinado";
        }
    }

    public void reiniciarFiltros()
    {
        //reinicio de filtros y repeater
        DDL_Precio.SelectedIndex = 0;
        DD_Marca.SelectedIndex = 0;
        DD_Categoria.SelectedIndex = 0;
    }

    protected void B_cerrar_mensaje1_Click(object sender, EventArgs e)
    {
        PanelMensaje1.Visible = false;
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        ClientScriptManager cm = this.ClientScript;
        //se obtiene el item del inventario    
        int precio = int.Parse(((Label)e.Item.FindControl("PrecioLabel")).Text);
        int stock = int.Parse(((Label)e.Item.FindControl("Ca_actualLabel")).Text);

        int cantidadSolicitada = int.Parse(((TextBox)e.Item.FindControl("TB_cantidad")).Text);
        //int cantidadDisponible = new DAOUser().ObtenerCantidadxProductoCarrito(int.Parse(e.CommandArgument.ToString()));
        int cantidadDisponible = new LUsuario().ObtenerCantidadxProductoCarrito(int.Parse(e.CommandArgument.ToString()));
        //primero buscar el control y validar que sea diferente de NULL 
        if (e.Item.FindControl("TB_cantidad") != null || cantidadSolicitada > cantidadDisponible)
        {
            //obtengo los valores de los controles y verifico cantidad de pedir a existente
            if (cantidadSolicitada > stock)
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Cantidad no disponible.');</script>");
                //MostrarMensaje1($"Cantidad no disponible");
                return;
            }

            UEncapCarrito verificarPedido = new UEncapCarrito();
            verificarPedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
            //var verificar1 = new DAOUser().verificarUsuarioTienePedido(verificarPedido);
            var verificar1 = new LUsuario().VerificarUsuarioTienePedido(verificarPedido);

            if (verificar1 != null)
            {
                UEncapCarrito verificarItem = new UEncapCarrito();
                verificarItem.Producto_id = int.Parse(e.CommandArgument.ToString());
                verificarItem.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                //verifico si el item agregado existe en el carrito 
                //var verificar2 = new DAOUser().verificarArticuloEnCarrito(verificarItem);
                var verificar2 = new LUsuario().VerificarArticuloEnCarrito(verificarItem);
                //si existe se suma  al item en el carrito 
                if (verificar2 != null)
                {
                    //actualizo cantidad de item existente en base de datos 
                    UEncapCarrito carrito = new UEncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;

                    //new DAOUser().ActualizarCarritoItems(carrito);
                    new LUsuario().ActualizarCarritoItems(carrito);
                }
                else
                {
                    //si no existe se agrega a la lista del carrito 
                    UEncapCarrito carrito = new UEncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    carrito.Estadocar = 1;
                    carrito.Id_pedido = verificar1.Id_pedido;
                    carrito.Session = Session["Nombre"].ToString();
                    carrito.Last_modify = DateTime.Now;
                    //new DAOUser().InsertarCarrito(carrito);
                    new LUsuario().InsertarCarrito(carrito);

                }

            }
            //////////////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                UEncapCarrito verificarItem = new UEncapCarrito();
                verificarItem.Producto_id = int.Parse(e.CommandArgument.ToString());
                verificarItem.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                //verifico si el item agregado existe en el carrito 
                //var verificar2 = new DAOUser().verificarArticuloEnCarrito(verificarItem);
                var verificar2 = new LUsuario().VerificarArticuloEnCarrito(verificarItem);

                //si existe se suma  al item en el carrito 
                if (verificar2 != null)
                {
                    //actualizo cantidad de item existente en base de datos 
                    UEncapCarrito carrito = new UEncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    carrito.Last_modify = DateTime.Now;
                    carrito.Session = Session["Nombre"].ToString();
                    new LUsuario().ActualizarCarritoItems(carrito);
                }
                else
                {
                    //si no existe se agrega a la lista del carrito 
                    UEncapCarrito carrito = new UEncapCarrito();
                    carrito.Producto_id = int.Parse(e.CommandArgument.ToString());
                    carrito.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                    carrito.Cantidad = cantidadSolicitada;
                    carrito.Fecha = DateTime.Now;
                    carrito.Precio = precio;
                    carrito.Total = precio * cantidadSolicitada;
                    carrito.Estadocar = 1;
                    carrito.Session = Session["Nombre"].ToString();
                    carrito.Last_modify = DateTime.Now;

                    //new DAOUser().InsertarCarrito(carrito);
                    new LUsuario().InsertarCarrito(carrito);
                }

            }

            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Producto agregado a carrito');</script>");
            Response.Redirect("catalogoUsuario.aspx");
            return;
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int stock = int.Parse(((Label)e.Item.FindControl("Ca_actualLabel")).Text);
        var cantidad = (TextBox)e.Item.FindControl("TB_cantidad");

        if (stock <= 0)
        {
            cantidad.Enabled = false;
        }
    }
}