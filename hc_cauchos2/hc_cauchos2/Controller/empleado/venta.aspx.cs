using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;

public partial class View_empleado_venta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UEncapUsuario usuarioo = new UEncapUsuario();
        usuarioo= new LLogin().usuarioActivo2((string)Session["correo"]);

        if (usuarioo == null || Session["Valido"] == null)
        {
            Response.Redirect("../home.aspx");
        }
        if (usuarioo.Rol_id != 2)
        {
            Response.Redirect("../home.aspx");
        }
        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
        PanelMensaje2.Visible = false;
    }

    protected void BTN_BuscarClien_Click(object sender, EventArgs e)
    {
        GV_Clientes.DataSourceID = "ODS_ClientesCedu";
    }

    protected void BTN_buscarTodos_Click(object sender, EventArgs e)
    {
        GV_Clientes.DataSourceID = "ODS_Clientes";
    }

    protected void BTN_RegistrarCliente_Click(object sender, EventArgs e)
    {
        Response.Redirect("registrarCliente.aspx");
    }

    protected void BTN_Facturar_Click(object sender, ImageClickEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        if (TB_Iduser.Text == "")
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar el ID asociado al cliente');", true);

            MostrarMensaje1($"Debe ingresar el Identificador asociado al cliente");
            return;
        }
        else
        {
            //verifico si el usuario tiene productos en carrito antes de facturar
            List<UEncapCarrito> listCarritoV = new LEmpleado().ObtenerCarritoxUsuario(((UEncapUsuario)Session["Valido"]).User_id);
            if (listCarritoV.Count == 0)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar productos antes de realizar una venta');", true);
                MostrarMensaje($"Debe ingresar productos antes de realizar una venta");
                return;
            }
            else
            {
                //creo objeto para cambiar el estado luego de facturar
                UEncapCarrito carrito = new UEncapCarrito();
                carrito.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
                carrito.Estadocar = 2;
                new LEmpleado().actualizarestadocarrito(carrito);

                //agrego a la tabla pedido
                UEncapPedido pedido = new UEncapPedido();
                pedido.Fecha_pedido = DateTime.Now;
                pedido.User_id = int.Parse(TB_Iduser.Text);
                pedido.Atendido_id = ((UEncapUsuario)Session["Valido"]).User_id;
                pedido.Estado_pedido = 6;
                List<UEncapCarrito> listCarrito = new LEmpleado().ObtenerCarritoxUsuario(pedido.Atendido_id);
                pedido.Total = listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
                int pedido_Id = new LEmpleado().insertarpedido(pedido);

                Session["pedido_Id"] = pedido_Id;

                //agrego a carrito el pedido
                UEncapCarrito id_pedido = new UEncapCarrito();
                id_pedido.User_id = int.Parse(TB_Iduser.Text);
                id_pedido.Id_pedido = pedido_Id;
                new LEmpleado().ActualizarIdpedidoCarrito(id_pedido);


                //recorreo los producto que tiene el usuario en carrito
                foreach (var product in listCarrito)
                {
                    //inserto los productos en productos del pedido
                    UEncapProducto_pedido producto = new UEncapProducto_pedido();
                    producto.Pedido_id = id_pedido.Id_pedido;
                    producto.Producto_id = product.Producto_id;
                    producto.Cantidad = product.Cantidad.Value;
                    producto.Precio = product.Precio;
                    producto.Total = product.Total;
                    new LEmpleado().InsertarProductos(producto);



                    //descuento la cantidad del producto en el inventario
                    UEncapInventario descontar = new UEncapInventario();
                    descontar.Id = product.Producto_id;
                    descontar.Ca_actual = product.Cantidad.Value;
                    new LEmpleado().ActualizarCantidadInventario(descontar);

                }

                //elimino los productos en carrito del usuario 
                int id_user = ((UEncapUsuario)Session["Valido"]).User_id;
                new LEmpleado().limpiarCarrito(id_user);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero el pedido No.00" + pedido_Id.ToString() + "');", true);
                Response.Redirect("FacturaVentanilla.aspx");
            }

        }
    }

    protected void GV_Clientes_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //ACTUALIZA VALOR DEL PEDIDO SI MODIFICAN CANTIDADES
        UEncapPedido pedido = new UEncapPedido();
        pedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
        List<UEncapCarrito> listCarrito2 = new LEmpleado().ObtenerCarritoxUsuario(pedido.User_id);
        int first = listCarrito2[0].Id_pedido;
        pedido.Total = listCarrito2.Sum(x => x.Precio * x.Cantidad).Value;
        pedido.Id = first;
        new LEmpleado().ActualizarValorpedido(pedido);
    }



    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        PanelMensaje2.Visible = false;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        PanelMensaje1.Visible = false;
    }

    protected void B_cerrar_mensaje1_Click(object sender, EventArgs e)
    {

        PanelMensaje.Visible = false;
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