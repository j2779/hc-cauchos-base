using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using LogicaNegocio;
using Datos;

public partial class View_usuario_Carrito : System.Web.UI.Page
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

        UEncapCarrito verificarPedido = new UEncapCarrito();
        verificarPedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;

        //var verificar1 = new DAOUser().verificarUsuarioTienePedido(verificarPedido);
        var verificar1 = new LUsuario().VerificarUsuarioTienePedido(verificarPedido);
        if (verificar1 != null)
        {
            BTN_facturar1.Visible = false;
            DDL_Lugar.Visible = false;
        }
        else
        {
            DDL_Lugar.Visible = true;
            BTN_facturar1.Visible = true;
        }

        PanelMensaje.Visible = false;
        PanelMensaje1.Visible = false;
        PanelMensaje2.Visible = false;
    }

    protected void BTN_facturar1_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        List<UEncapCarrito> listCarritoC = new LUsuario().ObtenerCarritoxUsuario(((UEncapUsuario)Session["Valido"]).User_id);
        if (listCarritoC.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Debe ingresar productos antes de realizar una compra');", true);
            //MostrarMensaje1($"Debe ingresar productos antes de realizar una compra");
            return;
        }
        else
        {
            //creo objeto para cambiar el estado luego de facturar
            UEncapCarrito carrito = new UEncapCarrito();
            carrito.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
            carrito.Estadocar = 2;
            //new DAOUser().ActualizarCarritoEstado(carrito);
            new LUsuario().ActualizarCarritoEstado(carrito);


            //agrego a la tabla pedido
            UEncapPedido pedido = new UEncapPedido();
            pedido.Fecha_pedido = DateTime.Now;
            pedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
            //pedido.Atendido_id = 5;
            //Campos de Direccion
            pedido.Ciu_dep_id = DDL_Lugar.SelectedIndex;
            //pedido.Municipio_id = DDL_Municipio.SelectedIndex;
            pedido.Direccion = TB_Direccion.Text;
            List<UEncapCarrito> listCarrito = new LUsuario().ObtenerCarritoxUsuario(pedido.User_id);
            pedido.Total = listCarrito.Sum(x => x.Precio * x.Cantidad).Value;
            //int pedido_Id = new DAOUser().InsertarPedido(pedido);
            int pedido_Id = new LUsuario().InsertarPedido(pedido);


            //agrego a carrito el pedido
            UEncapCarrito id_pedido = new UEncapCarrito();
            id_pedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
            id_pedido.Id_pedido = pedido_Id;
            //new DAOUser().ActualizarIdpedidoCarrito(id_pedido);
            new LUsuario().ActualizarIdpedidoCarrito(id_pedido);

            //obtengo tiempo de inventario
            UEncapParametros tiempo = new UEncapParametros();
            tiempo.Nombre = "tiempocarrito";
            //var time = new DAOUser().ObtenerTiempo(tiempo);
            var time = new LUsuario().ObtenerTiempo(tiempo);
            int tiempoadmin = int.Parse(time.Valor);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Se genero el pedido No.00" + pedido_Id.ToString() + "  ');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myAlert", "alert('Recuerde que tiene un tiempo de" + tiempoadmin.ToString() + " minutos para modificar su pedido y ver su factura  ');", true);
            Response.Redirect("Carrito.aspx");
            //MostrarMensaje2($"Se ha generado el pedido No. " + pedido_Id.ToString() + "");
            //MostrarMensaje1($"Recuerde que tiene un tiempo de " + tiempoadmin.ToString() + " minutos para modificar su pedido y ver su factura.");
            return;
        }
    }

    protected void BTN_mas_Click(object sender, EventArgs e)
    {
        Response.Redirect("catalogoUsuario.aspx");
    }

    protected void GV_carrito_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GV_carrito_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GV_carrito_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //ACTUALIZA VALOR DEL PEDIDO SI MODIFICAN CANTIDADES
        UEncapPedido pedido = new UEncapPedido();
        pedido.User_id = ((UEncapUsuario)Session["Valido"]).User_id;
        //List<UEncapCarrito> listCarrito2 = new DAOUser().ObtenerCarritoxUsuario(pedido.User_id);
        List<UEncapCarrito> listCarrito2 = new LUsuario().ObtenerCarritoxUsuario(pedido.User_id);
        int first = listCarrito2[0].Id_pedido;
        if (first != 0)
        {
            pedido.Total = listCarrito2.Sum(x => x.Precio * x.Cantidad).Value;
            pedido.Id = first;
            //new DAOUser().ActualizarValorpedido(pedido);
            new LUsuario().ActualizarValorpedido(pedido);
        }
    }

    protected void DDL_Lugar_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        var db = new Mapeo();

        TB_Direccion.Visible = true;
    }

    protected void B_cerrar_mensaje1_Click(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}