using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BootCamp.ApiSpfx.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("api/produtos")]
        public IHttpActionResult GetProducts()
        {
            return Ok("First route with .NET Web Api.");
        }
    }
}
