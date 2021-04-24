using System;
using System.Web.Http;
using Utilitarios;
using LogicaNegocio;


namespace hccauchosAPI.Controllers
{
    [RoutePrefix("api")]

    public class RegistroController : ApiController
    {
        [HttpPost]
        [Route("registro")]
        public string Registro(UEncapUsuario usuario)
        {
            UEncapUsuario verificar = new UEncapUsuario();
            verificar.Correo = usuario.Correo;
            verificar.Identificacion = usuario.Identificacion;
            string mensaje="";

            bool veri1 = new LLogin().verificarCorreo(verificar);
            bool veri2 = new LLogin().verificarIdentificacion(verificar);

            if (veri1 == false)
            {
                 mensaje = "el correo ya se encuentra registrado";
            }

            if (veri2 == false)
            {
                return mensaje = "la idetificacion ya se encuentra registrada";
            }

            if (veri1==false && veri2 == false)
            {
               return mensaje = "los datos ya estan registrados";
            }

            if (veri1 == true && veri2 == true)
            {
                new LLogin().insertarUsuario(usuario);
                return mensaje = "el usuario se ha registrado satisfactoriamente";
            }

            return mensaje;
        }


    }
}
