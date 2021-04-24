using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;


namespace LogicaNegocio
{
    public class LDomiciliario
    {
        //trae consulta de usuario
        public UEncapUsuario usuarioactivo(string nombre)
        {
            UEncapUsuario usuario = new UEncapUsuario();
            return usuario = new DAODomiciliario().UsuarioActivo(nombre);
        }
        //trae la consulta de la verificacion de correo existente
        public UEncapUsuario verificarCorreo(UEncapUsuario correo)
        {
            UEncapUsuario usuario = new UEncapUsuario();
            return usuario = new DAODomiciliario().verificarCorreo(correo);
        }
        //actualizacion datos del user
        public void actualizaruser(UEncapUsuario usuario)
        {
            new DAODomiciliario().ActualizarUsuario(usuario);
        }
        //actualizar entrega pedido
        public void actualizarnovedad(UEncapPedido pedido)
        {
            new DAODomiciliario().ActualizarNovedadPedido(pedido);
        }
        public List<UEncapPedido> pedidosdomiciliario()
        {
           var pedidos = new DAODomiciliario().ObtenerPedidos();
            return pedidos;
        }

    }
}
