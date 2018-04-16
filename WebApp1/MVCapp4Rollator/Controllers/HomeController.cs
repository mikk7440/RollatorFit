using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCapp4Rollator.Models;
using Microsoft.Extensions.Configuration;

namespace MVCapp4Rollator.Controllers
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
            ViewData["deviceID"] = Configuration["deviceID"];
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "The Intellegient walker";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
