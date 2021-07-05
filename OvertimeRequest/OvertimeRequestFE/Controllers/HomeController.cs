using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OvertimeRequestFE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestFE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            ViewBag.sessionNip = tokenS.Claims.First(claim => claim.Type == "NIP").Value;
            ViewBag.sessionFName = tokenS.Claims.First(claim => claim.Type == "FirstName").Value;
            ViewBag.sessionLName = tokenS.Claims.First(claim => claim.Type == "LastName").Value;
            ViewBag.sessionRole = tokenS.Claims.First(claim => claim.Type == "role").Value;
            ViewBag.sessionEmail = tokenS.Claims.First(claim => claim.Type == "Email").Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
