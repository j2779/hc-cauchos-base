using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_empleado_facturar : System.Web.UI.Page
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
        //obtengo el usuario que esta en session en el momento 
        int iduser = ((UEncapUsuario)Session["Valido"]).User_id;
        Session["userid"] = iduser;
        //numero de cantidad en el carrito 
        //LB_cantidad.Text = new DAOEmpleado().ObtenerCantidadxProductoCarritoxEmple(iduser).ToString();

        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
        PanelMensaje2.Visible = false;
    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        //se obtiene el item del inventario    
        int precio = int.Parse(((Label)e.Item.FindControl("PrecioLabel")).Text);
        int stock = int.Parse(((Label)e.Item.FindControl("Ca_actualLabel")).Text);
        int cantidadSolicitada = int.Parse(((TextBox)e.Item.FindControl("TB_cantidad")).Text);
        int cantidadDisponible = new LEmpleado().obtenerproductoxcarito(int.Parse(e.CommandArgument.ToString()));
        //primero buscar el control y validar que sea diferente de NULL 
        if (e.Item.FindControl("TB_cantidad") != null || cantidadSolicitada > cantidadDisponible)
        {
            //obtengo los valores de los controles y verifico cantidad de pedir a existente
            if (cantidadSolicitada > stock)
            {
                MostrarMensaje1($"Cantidad no disponible");
                return;
                //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Cantidad no disponible.');</script>");
                //return;
            }

            UEncapCarrito verificarPedido = new UEncapCarrito();
            verificarPedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
            var verificar1 = new LEmpleado().verificarUsuarioTienePedido(verificarPedido);
            //verifica si el vendedor esta atendiendo pedido 
            if (verificar1 != null)
            {
                UEncapCarrito verificarItem = new UEncapCarrito();
                verificarItem.Producto_id = int.Parse(e.CommandArgument.ToString());
                verificarItem.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                //verifico si el item agregado existe en el carrito 
                var verificar2 = new LEmpleado().verificaritemcarrito(verificarItem);
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
                    new LEmpleado().ActualizarCarritoItems(carrito);
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
                    new LEmpleado().InsertarCarrito(carrito);
                }

            }
           
            else
            {
                UEncapCarrito verificarItem = new UEncapCarrito();
                verificarItem.Producto_id = int.Parse(e.CommandArgument.ToString());
                verificarItem.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                //verifico si el item agregado existe en el carrito 
                var verificar2 = new LEmpleado().verificaritemcarrito(verificarItem);
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
                    new LEmpleado().ActualizarCarritoItems(carrito);
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
                    new LEmpleado().InsertarCarrito(carrito);
                }

            }



            Response.Redirect("facturar.aspx");
            //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert ('Producto agregado a carrito');</script>");
            //return;
        }
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

    protected void Btn_Todos_Click(object sender, EventArgs e)
    {
        Repeater1.DataSourceID = "ODS_catalogo";
        DDL_Precio.SelectedIndex = 0;
        DD_Marca.SelectedIndex = 0;
        DD_Categoria.SelectedIndex = 0;
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