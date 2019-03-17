using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TenkenWeb.Common;
using TenkenWeb.Models;
using TenkenWeb.Providers;

namespace TenkenWeb.Controllers
{
    [Route("api/[controller]")]
    public class UserManagerController : Controller
    {
        SqlConnection connection = DBProvider.getDbConnection();
        [HttpPost("[action]")]
        public bool Login([FromBody] User user)
        {
            bool result = UserManagerProvider.login(connection, user.userName, user.password);
            return result;
        }

        [HttpPost("[action]")]
        public HttpResult Register([FromBody] User user)
        {
            HttpResult result = UserManagerProvider.register(connection, user.userName, user.password);
            return result;
        }
    }
    public class User
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
