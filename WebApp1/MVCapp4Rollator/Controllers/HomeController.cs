using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCapp4Rollator.Models;
using Microsoft.Extensions.Configuration;
using MVCapp4Rollator.Data;

namespace MVCapp4Rollator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public IConfiguration Configuration { get; set; }

        public HomeController(IConfiguration config, ApplicationDbContext dbContext)
        {
            Configuration = config;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewData["acessToken"] = Configuration["acessToken"];
            ViewData["deviceID"] = Configuration["deviceID"];
            return View();
        }

        public IActionResult About()
        {
            return View(dbContext.AboutModel.First<AboutModel>());
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
