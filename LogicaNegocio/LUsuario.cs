using Utilitarios;
using Datos;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class LUsuario
    {
        public void EliminarUsuario(UEncapUsuario usuario)
        {
            new DaoUsuario().EliminarCuenta(usuario);
        }

        public int ObtenerCantidadCarritoUser(int user)
        {
            int valor = new DaoUsuario().ObtenerCantidadxProductoCarritoxUser(user);
            return valor;
        }

        public int ObtenerCantidadxProductoCarrito(int producto_id)
        {
            int cantidad = new DaoUsuario().ObtenerCantidadxProductoCarrito(producto_id);
            return cantidad;
        }

        public UEncapCarrito VerificarUsuarioTienePedido(UEncapCarrito usuario)
        {
            var verificar = new DaoUsuario().verificarUsuarioTienePedido(usuario);
            return verificar;   
        }

        public UEncapCarrito VerificarArticuloEnCarrito(UEncapCarrito articulo)
        {
            var verificar = new DaoUsuario().verificarArticuloEnCarrito(articulo);
            return verificar;
        }
        public void ActualizarCarritoItems(UEncapCarrito carrito)
        {
            new DaoUsuario().ActualizarCarritoItems(carrito);
        }
        public void InsertarCarrito(UEncapCarrito carrito)
        {
            new DaoUsuario().InsertarCarrito(carrito);
        }

        public List<UEncapInventario> ConsultarInventario()
        {
            var inventario = new DaoUsuario().ConsultarInventario();
            return inventario;
        }

        public List<UEncapInventario> ConsultarInventarioCategoria(int categ)
        {
            var inventario = new DaoUsuario().ConsultarInventarioCategoria(categ);
            return inventario;
        }
        public List<UEncapInventario> ConsultariMarca(int marca)
        {
            var inventario = new DaoUsuario().ConsultarInventariMarca(marca);
            return inventario;
        }
        public List<UEncapInventario> ConsultarInventariCombinado(int marca, int categ)
        {
            var inventario = new DaoUsuario().ConsultarInventariCombinado(marca, categ);
            return inventario;
        }
        public List<UEncapInventario> ConsultarInventaroiPrecio(string valores)
        {
            var inventario = new DaoUsuario().ConsultarInventarioPrecio(valores);
            return inventario;
        }
        public List<UEncapInventario> ConsultarInventaroiPrecioCategoria(string valores, int categ)
        {
            var inventario = new DaoUsuario().ConsultarInventarioPrecioCategoria(valores, categ);
            return inventario;
        }

        public List<UEncapInventario> ConsultarInventaroiPrecioMarca(string valores, int marca)
        {
            var inventario = new DaoUsuario().ConsultarInventarioPrecioMarca(valores, marca);
            return inventario;
        }

        public List<UEncapInventario> ConsultarInventaroiPrecioCombinado(string valores, int marca, int categor)
        {
            var inventario = new DaoUsuario().ConsultarInventarioPrecioCombinado(valores, marca,categor);
            return inventario;
        }

        public List<UEncapCarrito> ObtenerCarritoxUsuario(int usu)
        {
            var carrito = new DaoUsuario().ObtenerCarritoxUsuario(usu);
            return carrito;
        }

        public void ActualizarValorpedido(UEncapPedido pedido)
        {
            new DaoUsuario().ActualizarValorpedido(pedido);
        }

        public void ActualizarCarritoEstado(UEncapCarrito carrito)
        {
            new DaoUsuario().ActualizarCarritoEstado(carrito);
        }

        public int InsertarPedido(UEncapPedido pedido)
        {
            int id =new DaoUsuario().InsertarPedido(pedido);
            return id;
                 
        }

        public void ActualizarIdpedidoCarrito(UEncapCarrito carrito)
        {
            new DaoUsuario().ActualizarIdpedidoCarrito(carrito);
        }

        public UEncapParametros ObtenerTiempo(UEncapParametros tiempo)
        {
            var time = new DaoUsuario().ObtenerTiempo(tiempo);
            return time;

        }
        public List<UEncapPedido> ObtenerPedidosActivo(int usu)
        {
            return new DaoUsuario().ObtenerPedidosActivo(usu);
        }
        public List<UEncapPedido> ObtenerPedidosFin(int usu)
        {
            return new DaoUsuario().ObtenerPedidosFin(usu);
        }

        public List<UEncapProducto_pedido> ObtenerProductos(int id)
        {
            return new DaoUsuario().ObtenerProductos(id);
        }

        public void ActualizarCarritoFactura(UEncapCarrito carrito)
        {
             new DaoUsuario().ActualizarCarritoFactura(carrito);
        }


    }

}
