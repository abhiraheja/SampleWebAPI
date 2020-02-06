using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbLayer.Framework;
using DbLayer.Framework.Tables;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        IDbEntity dbModel;
        public HomeController(IDbEntity dbModel)
        {
            this.dbModel = dbModel;
        }
        public IActionResult Index()
        {
            dbModel.dbMigrate();
            return Ok(new { Active_Link = "https://localhost:5001/swagger/index.html" });
        }
    }
}