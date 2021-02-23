using BootCamp.ApiSpfx.Models;
using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.ServiceModel.Description;
using System.Web.Http;

namespace BootCamp.ApiSpfx.Controllers
{
    /// <summary>
    /// Controler responsável por retornar produtos.
    /// </summary>
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Listagem de produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/produtos")]
        public IHttpActionResult GetProducts()
        {
            using (ClientContext ctx = new ClientContext("https://inparlabsdev.sharepoint.com/sites/jh-bootcamp-restapi-spfx"))
            {
                var login = ConfigurationManager.AppSettings["User"];
                var password = ConfigurationManager.AppSettings["Password"];

                Web web = ctx.Web;
                SecureString pwd = new SecureString();
                foreach (char c in password) pwd.AppendChar(c);

                ctx.Credentials = new SharePointOnlineCredentials(login, pwd);
                ctx.ExecuteQuery();

                var listItems = ctx.Web.Lists.GetByTitle("Products").GetItems(new CamlQuery()
                {
                    ViewXml = ""
                });

                ctx.Load(listItems);
                ctx.ExecuteQuery();

                List<Product> listProducts = new List<Product>();

                foreach (var item in listItems)
                {
                    listProducts.Add(new Product(
                        item["Title"].ToString(),
                        item["Model"].ToString(),
                        item["Ano"].ToString()));
                }

                return Ok(listProducts);
            }


        }

        [HttpPost]
        [Route("api/produtos")]
        public IHttpActionResult PostProduct() 
        {
            return Ok("Created");
        }
    }
}
