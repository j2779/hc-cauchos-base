using System.Web.Http;
using Newtonsoft.Json;
using Utilitarios;
using LogicaNegocio;
using System;

namespace WebApiSegura.Controllers
{

    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var customerFake = "customer-fake: " + id;
            return Ok(customerFake);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customersFake ="prueba";
            return Ok(customersFake);
        }

    }
}
