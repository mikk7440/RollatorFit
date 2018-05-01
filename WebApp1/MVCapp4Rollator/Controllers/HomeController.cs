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
            
            var viewModel = new AboutModel()
            {
                Title = "The Intellegient walker",
                Text = " Some text."
            };

            return View(viewModel);
        }

        public IActionResult Gallery()
        {
            ViewData["Message"] = "Your Gallery page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
