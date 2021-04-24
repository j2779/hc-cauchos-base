
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using Utilitarios;
using LogicaNegocio;
using System;
using System.Collections.Generic;

namespace hccauchosAPI.Controllers
{
    //required token and establish role
    [Authorize (Roles ="1")]
    public class AdminController : ApiController
    {

        [HttpGet]
        public UEncapUsuario obtenerAdmin()
        {
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.Email);

            UEncapUsuario usu = new UEncapUsuario();
            usu.Correo = valor.Value;

            var usua = new LAdministrador().obtenerAdmin(usu);
            
            return usua;
           
        }

        [HttpPut]
        public string modificarContraseña(UEncapUsuario newcontraseña)
        {
            string mensaje = "";
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            UEncapUsuario usu = new UEncapUsuario();
            usu.User_id = Int32.Parse(valor.Value);
            usu.Clave = newcontraseña.Clave;
           

            new LAdministrador().actualizarContraseña(usu);

            if (newcontraseña == null)
            {
                mensaje = "debe ingresar la contraseña a cambiar";
            }
            else
            {
                mensaje = "la contraseña se ha modificado satisfactoriamente";
            }
            return mensaje;
        }

        [HttpPut]
        public string modificarCorreo(UEncapUsuario newcorreo)
        {
            string mensaje = "";
            var claimsIdentity = (ClaimsIdentity)Thread.CurrentPrincipal.Identity;
            var valor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            UEncapUsuario usu = new UEncapUsuario();
            usu.User_id = Int32.Parse(valor.Value);
            usu.Correo = newcorreo.Correo;

            bool verificar = new LAdministrador().verifcarCorreo(usu);
            if (verificar)
            {
                return "el correo ya se encuentra asociado a una cuenta";
            }
            else
            {
                new LAdministrador().actualizarCorreo(usu);

                if (newcorreo == null)
                {
                    return "debe ingresar el correo a cambiar";
                }
                else
                {
                    return "el correo se ha modificado satisfactoriamente";
                }
            }

        }


        [HttpGet]
        public List<UEncapPedido> ConsultarPedidos()
        {
            List<UEncapPedido> historial =new LAdministrador().ConsultarPedidos();
            return historial;
        }

        [HttpGet]
        public List<UEncapPedido> ConsultVentas()
        {
            List<UEncapPedido> ventas = new LAdministrador().ConsultarVentas();
            return ventas;
        }

        [HttpPost]
        public string InsertarItem(UEncapInventario item)
        {
            
            if(item != null)
            {
                new LAdministrador().insertarItem(item);
                return "Agregado correctamente.";
            }
            else
            {
                return "No se pude insertar, verifique por favor.";
            }
            
        }
        
    }
}
