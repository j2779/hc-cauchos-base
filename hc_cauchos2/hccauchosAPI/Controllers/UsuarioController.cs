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
using System.Web.Http.Cors;

namespace hccauchosAPI.Controllers
{
    // [Authorize(Roles = "4")]
    [EnableCors(origins: "anonymous", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        //metodo para eliminar cuenta
        [HttpDelete]
        public void eliminar()
        {
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            UEncapUsuario user = new UEncapUsuario();
            user.User_id = Int32.Parse(valor.Value);

            new LUsuario().EliminarUsuario(user);
        }
        [HttpPut]
        public string editarcorreo(UEncapUsuario correo)
        {
            //string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyOCIsImVtYWlsIjoiYWRtaW5AaG90bWFpbC5jb20iLCJ1bmlxdWVfbmFtZSI6ImFkbWluIiwiY2VydHNlcmlhbG51bWJlciI6IjEwNzA5ODY4ODEiLCJyb2xlIjoiMSIsImdlbmRlciI6IjEiLCJuYmYiOjE2MTYwMjAwNDIsImV4cCI6MTYxNjAyMDY0MiwiaWF0IjoxNjE2MDIwMDQyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjU1MTQ3IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1NTE0NyJ9.yPR5xnJAaodHl2CfBdcJsLdARPrzZ-guldzAJmDMT4Q";
            string mensaje = "";
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            UEncapUsuario user = new UEncapUsuario();
            user.User_id = Int32.Parse(valor.Value);
            user.Correo = correo.Correo;

            bool verificar = new LAdministrador().verifcarCorreo(user);
            if (verificar != false)
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
                    new LAdministrador().actualizarCorreo(user);
                    mensaje = "correo actualizado satisfactoriamente";
                }
            }
            return mensaje;
        }
        //metodo para actualizar contraseña del user
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
                new LAdministrador().actualizarContraseña(user);
                mensaje = "contraseña actuañizada satisfactoriamente";
            }
            return mensaje;
        }
        //metodo para llamar pedidos
        [HttpGet]
        public List<UEncapPedido> obtenerpedidos()
        {
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int userid = Int32.Parse(valor.Value);

            return new LUsuario().ObtenerPedidosActivo(userid);

        }
        //metodo para obtener pedidos finalizados
        [HttpGet]
        public List<UEncapPedido> pedidosfinalizados()
        {

            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            int userid = Int32.Parse(valor.Value);

            return new LUsuario().ObtenerPedidosFin(userid);
        }

        //metodo para mostrar catalogo
        [HttpGet]
        public List<UEncapInventario> catalogo()
        {
            return new LUsuario().ConsultarInventario();
        }
        //metodo para mostrar catalogo por categoria
        [HttpGet]
        public List<UEncapInventario> catalogocategoria(catalogocat categ)
        {

            return new LUsuario().ConsultarInventarioCategoria(categ.categoria);
        }
        //metodo para mostrar catalogo por marca
        [HttpGet]
        public List<UEncapInventario> catalogomarca(catalogomarca marca)
        {
            return new LUsuario().ConsultariMarca(marca.marca);
        }
        //metodo para mostrar catalogo combinado
        [HttpGet]
        public List<UEncapInventario> catalogocombinado(catalogocombinado combinado)
        {
            return new LUsuario().ConsultarInventariCombinado(combinado.marca, combinado.categoria);
        }

        //metodo para mostrar catalogo precio
        [HttpGet]
        public List<UEncapInventario> catalogoprecio(catalogoprecio valor)
        {
            return new LUsuario().ConsultarInventaroiPrecio(valor.precio);
        }
        //metodo para mostrar catalogo precio y categoria
        [HttpGet]
        public List<UEncapInventario> catalogopreciocate(catalogopreciocategoria preciocateg)
        {
            return new LUsuario().ConsultarInventaroiPrecioCategoria(preciocateg.precio, preciocateg.categoria);
        }
        //metodo para mostrar catalogo precio y marca
        [HttpGet]
        public List<UEncapInventario> catalogopreciomarca(catalogopreciomarca preciomarca)
        {

            return new LUsuario().ConsultarInventaroiPrecioMarca(preciomarca.precio, preciomarca.marca);
        }
        //metodo para mostrar catalogo precio,marca ycategoria
        [HttpGet]
        public List<UEncapInventario> catalogopreciocombinado(combinadorequest requeridos)
        {
            return new LUsuario().ConsultarInventaroiPrecioCombinado(requeridos.precio, requeridos.marca, requeridos.categoria);
        }

    }
}
