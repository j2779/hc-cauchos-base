using System;
using LogicaNegocio;
using Utilitarios;
using System.Web.Http;
using Newtonsoft.Json;

namespace hccauchosAPI.Controllers
{
    public class Recuperar_ContraseñaController : ApiController
    {
        [HttpPost]
        public string Recuperar_Clave(UEncapUsuario correo)
        {
            string mensaje;
            UEncapUsuario usuario = new LLogin().verificarCorreoRecuperacion(correo.Correo);
            if (usuario != null)
            {
                //encriptacion de token
                usuario.Clave = "";
                usuario.Estado_id = 2;
                usuario.Token = new LLogin().encriptar(JsonConvert.SerializeObject(usuario.Token));
                usuario.Tiempo_token = DateTime.Now.AddDays(1);

                new Correo().enviarCorreo(usuario.Correo, usuario.Token, "");
                new LLogin().actualizarUsuario(usuario);
                mensaje = "Token enviado por favor verifique el su correo";
            }
            else
            {
                mensaje = "Correo no encontrado";
            }
            return mensaje;
        }
    }
}
