using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; set; }

        public HomeController(IConfiguration config)
        {
            Configuration = config;
        }


        public IActionResult Index()
        {
            ViewData["acessToken"] = Configuration["acessToken"];
            ViewData["deviceID"] = Configuration.GetConnectionString("deviceID");
            return View();
        }
    }
}