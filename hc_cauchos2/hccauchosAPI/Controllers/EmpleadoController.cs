using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using LogicaNegocio;
using System;
using System.Security.Claims;
using System.Threading;

namespace hccauchosAPI.Controllers
{
    //[Authorize(Roles = "2")]
    public class EmpleadoController : ApiController
    {
        //editar correo del Empleado
        [HttpPut]
        public string editarcorreo(UEncapUsuario correo)
        {
            string mensaje = "";
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            UEncapUsuario user = new UEncapUsuario();
            user.User_id = Int32.Parse(valor.Value);
            user.Correo = correo.Correo;

            user = new LEmpleado().verificarCorreo(user);
            if (user != null)
            {
                mensaje = "el correo ya existe encuentra asociado a una cuenta";
            }
            else
            {
                if (correo == null)
                {
                    mensaje = "debe ingresar un correo";
                }
                else
                {
                    new LEmpleado().actualizaruser(user);
                    mensaje = "correo actualizado satisfactoriamente";
                }
            }
            return mensaje;
        }
        //metodo para actualizar contraseña del Empleado
        [HttpPut]
        public string modificarclave(UEncapUsuario usuario)
        {
            string mensaje = "";
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            UEncapUsuario user = new UEncapUsuario();
            user.User_id = Int32.Parse(valor.Value);
            user.Clave = usuario.Clave;

            if (usuario == null)
            {
                mensaje = "debe ingresar la nueva clave";
            }
            else
            {
                new LEmpleado().actualizaruser(user);
                mensaje = "contraseña actualizada satisfactoriamente";
            }
            return mensaje;
        }
        [HttpGet]
        public List<UEncapProducto_pedido> pedidos(pedidosrequest pedido)
        {
            return new LEmpleado().ObtenerProductos(pedido.pedido);
        }
        [HttpGet]
        public List<UEncapProducto_pedido> obtenerpedidos(pedidosrequest empleadoid)
        {
            return new LEmpleado().ObtenerProductos(empleadoid.empleadoid);
        }
        [HttpPost]
        public void alistar(UEncapPedido pedido)
        {
            new LEmpleado().ActualizarEstadoPedido2(pedido);
        }
        [HttpPost]
        public void confirmarpedido(pedidosrequest pedido)
        {
            UEncapPedido novedad = new UEncapPedido();
            novedad.Novedad = pedido.novedad;
            novedad.Estado_pedido = 3;
            new LEmpleado().ActualizarNovedadPedido(novedad);
            new LEmpleado().ActualizarEstadoPedido3(novedad);
            UEncapUsuario user = new UEncapUsuario();
            user.User_id = pedido.empleadoid;
            user.Estado_id = 1;
            new LEmpleado().ActualizarEstadoEmpleado(user);
        }
        [HttpPost]
        public string registrarcliente(UEncapUsuario registro)
        {
            string mensaje = "";
            UEncapUsuario user = new UEncapUsuario();
            user.Correo = registro.Correo;
            UEncapUsuario identificacion = new UEncapUsuario();
            identificacion.Identificacion = registro.Identificacion;

            user = new LEmpleado().verificarCorreo(user);
            identificacion = new LEmpleado().verificaridentificacion(identificacion);
            if (user == null && identificacion == null)
            {
                new LEmpleado().InsertarCliente(registro);
                //new LEmpleado().InsertarEmpleado(registro);
                mensaje = "el empleado fue registrado";

            }
            else
            {
                mensaje = "no se ha registrado el cliente verifique los datos";
            }
            return mensaje;
        }
        [HttpGet]
        public List<UEncapUsuario> obtener()
        {
            return new LEmpleado().ObtenerClientes();
        }
        [HttpGet]
        public List<UEncapUsuario> clientescedula(string cedula)
        {
            return new LEmpleado().ObtenerClientesCedula(cedula);
        }


    }
}
