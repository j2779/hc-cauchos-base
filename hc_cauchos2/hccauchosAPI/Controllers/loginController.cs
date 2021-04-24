using System.Web.Http;
using System.Web.Http.Cors;
using LogicaNegocio;
using Utilitarios;
using WebApiSegura.Security;
using System.Collections.Generic;

namespace hccauchosAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class loginController : ApiController
    {

        [HttpPost]
        public IHttpActionResult login(LoginRequest login)
        {
            string mensaje;
            if (!ModelState.IsValid) 
            {
                string error = "Datos incorrectos.";

                foreach (var state in ModelState)
                {
                    foreach (var item in state.Value.Errors)
                    {
                        error += $" {item.ErrorMessage}";
                    }

                }
                return BadRequest(error);
            }
            UEncapUsuario user = new LLogin().login2(login);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(user);
                user.Token = token;
                new LEmpleado().actualizaruser(user);
                return Ok(user);
            }
            
        }
    }
}
