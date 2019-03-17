using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TenkenWeb.Models;
using TenkenWeb.Common;
using TenkenWeb.Providers;

namespace TenkenWeb.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        SqlConnection connect = DBProvider.getDbConnection();

        [HttpGet("[action]")]
        public IList<Cart> getCart(int userID)
        {
            IList<Cart> result = CartProvider.getCart(connect, userID);
            return result;
        }

        [HttpPost("[action]")]
        [HttpPut("[action]")]
        public HttpResult addCart([FromBody]Cart cart)
        {
            HttpResult result = CartProvider.addCart(connect, cart);
            return result;
        }

        [HttpDelete("[action]")]
        public HttpResult buy([FromBody] int userID)
        {
            HttpResult result = CartProvider.buy(connect, userID);
            return result;
        }
    }
}