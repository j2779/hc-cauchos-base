using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;

namespace LogicaNegocio
{
    public class LEmpleado
    {
        //trae consulta de usuario
        public UEncapUsuario usuarioactivo(string nombre)
        {
            UEncapUsuario usuario = new UEncapUsuario();
            return usuario = new DAOEmpleado().UsuarioActivo(nombre);
        }
        //trae la consulta de la verificacion de correo existente
        public UEncapUsuario verificarCorreo(UEncapUsuario correo)
        {
            UEncapUsuario usuario = new UEncapUsuario();
            return usuario = new DAOEmpleado().verificarCorreo(correo);
        }
        //actualizacion datos del user
        public void actualizaruser(UEncapUsuario usuario)
        {
            new DAOEmpleado().ActualizarUsuario(usuario);
        }
        //metodo para obtener la cantidad dispnibles
        public int obtenerproductoxcarito(int id)
        {
            int cantidad;
            return cantidad = new DAOEmpleado().ObtenerCantidadxProductoCarrito(id);
        }
        //
        public UEncapCarrito verificarUsuarioTienePedido(UEncapCarrito carrito)
        {
            UEncapCarrito verificar = new UEncapCarrito();
            return verificar = new DAOEmpleado().verificarUsuarioTienePedido(carrito);
        }
        //
        public UEncapCarrito verificaritemcarrito(UEncapCarrito verificar)
        {
            UEncapCarrito item = new UEncapCarrito();
            return item = new DAOEmpleado().verificarArticuloEnCarrito(verificar);
        }
        //
        public void ActualizarCarritoItems(UEncapCarrito carrito)
        {
            new DAOEmpleado().ActualizarCarritoItems(carrito);
        }
        //
        public void InsertarCarrito(UEncapCarrito insertar)
        {
            new DAOEmpleado().InsertarCarrito(insertar);
        }
        //
        public List<UEncapInventario> consultarinventario()
        {
            var inventario = new DAOEmpleado().ConsultarInventario();
            return inventario;
        }
        //
        public List<UEncapInventario> consultarinventariocategoria(int categoria)
        {
            var inventario = new DAOEmpleado().ConsultarInventarioCategoria(categoria);
            return inventario;
        }
        //
        public List<UEncapInventario> consultarinventariomarca(int marca)
        {
            var inventario = new DAOEmpleado().ConsultarInventariMarca(marca);
            return inventario;
        }
        public List<UEncapInventario> consultarinventariocombinado(int categoria, int marca)
        {
            var inventario = new DAOEmpleado().ConsultarInventariCombinado(categoria, marca);
            return inventario;
        }
        public List<UEncapInventario> consultarinventarioprecio(string valores)
        {
            var inventario = new DAOEmpleado().ConsultarInventarioPrecio(valores);
            return inventario;
        }
        public List<UEncapInventario> consultarinventariopreciocategoria(string valores, int categoria)
        {
            var inventario = new DAOEmpleado().ConsultarInventarioPrecioCategoria(valores, categoria);
            return inventario;
        }
        public List<UEncapInventario> consultarinventariopreciomarca(string valores, int marca)
        {
            var inventario = new DAOEmpleado().ConsultarInventarioPrecioMarca(valores, marca);
            return inventario;
        }
        public List<UEncapInventario> consultarinventariopreciocombinado(string valores, int marca, int categoria)
        {
            var inventario = new DAOEmpleado().ConsultarInventarioPrecioCombinado(valores, marca, categoria);
            return inventario;
        }
        public List<UEncapCategoria> consultarcategoria()
        {
            var inventario = new DAOEmpleado().ColsultarCategoria2();
            return inventario;
        }
        public List<UEncapMarca> consultarmarca()
        {
            var inventario = new DAOEmpleado().ColsultarMarca();
            return inventario;
        }
        public UEncapUsuario verificaridentificacion(UEncapUsuario user)
        {
            UEncapUsuario usuario = new UEncapUsuario();
            return usuario = new DAOEmpleado().verificarIdentificacion(user);
        }
        public void InsertarCliente(UEncapUsuario user)
        {
            new DAOEmpleado().InsertarCliente(user);
        }

        public void InsertarEmpleado(UEncapUsuario user)
        {
            new DAOEmpleado().InsertarEmpleado(user);
        }
        public void actualizarestadocarrito(UEncapCarrito carrito)
        {
            new DAOEmpleado().ActualizarCarritoEstado(carrito);
        }
        public List<UEncapCarrito> ObtenerCarritoxUsuario(int usuario)
        {
            return new DAOEmpleado().ObtenerCarritoxUsuario(usuario);
        }
        public int insertarpedido(UEncapPedido pedido)
        {
            return new DAOEmpleado().InsertarPedido(pedido);
        }
        public void ActualizarIdpedidoCarrito(UEncapCarrito pedido)
        {
            new DAOEmpleado().ActualizarIdpedidoCarrito(pedido);
        }
        public void InsertarProductos(UEncapProducto_pedido producto)
        {
            new DAOEmpleado().InsertarProductos(producto);
        }
        public void ActualizarCantidadInventario(UEncapInventario producto)
        {
            new DAOEmpleado().ActualizarCantidadInventario(producto);
        }
        public void limpiarCarrito(int userid)
        {
            new DAOEmpleado().limpiarCarrito(userid);
        }
        public void ActualizarValorpedido(UEncapPedido pedido)
        {
            new DAOEmpleado().ActualizarValorpedido(pedido);
        }
        public List<UEncapUsuario> ObtenerClientes()
        {
            return new DAOEmpleado().ObtenerClientes();
        }
        public List<UEncapUsuario> ObtenerClientesCedula(string cedula)
        {
            return new DAOEmpleado().ObtenerClientesCedula(cedula);
        }
        public void EliminarItemCarrito(UEncapCarrito carrito)
        {
            new DAOEmpleado().EliminarItemCarrito(carrito);
        }
        public void ActualizarCarritoFactura(UEncapCarrito carrito)
        {
            new DAOEmpleado().ActualizarCarritoFactura(carrito);
        }
        public void ActualizarEstadoPedido2(UEncapPedido pedido2)
        {
            new DAOEmpleado().ActualizarEstadoPedido2(pedido2);
        }
        public void ActualizarNovedadPedido(UEncapPedido novedad)
        {
            new DAOEmpleado().ActualizarNovedadPedido(novedad);
        }
        public void ActualizarEstadoPedido3(UEncapPedido pedido3)
        {
            new DAOEmpleado().ActualizarEstadoPedido3(pedido3);
        }
        public void ActualizarEstadoEmpleado(UEncapUsuario empleado)
        {
            new DAOEmpleado().ActualizarEstadoEmpleado(empleado);
        }
        public List<UEncapProducto_pedido> ObtenerProductos(int pedido)
        {
            return new DAOEmpleado().ObtenerProductos(pedido);
        }
        public List<UEncapPedido> ObtenerPedidos(int user)
        {
            return new DAOEmpleado().ObtenerPedidos(user);
        }
        public List<UEncapMunicipio> ConsultarMunicipio()
        {
            return new DAOEmpleado().ConsultarMunicipio();
        }
    }
}
