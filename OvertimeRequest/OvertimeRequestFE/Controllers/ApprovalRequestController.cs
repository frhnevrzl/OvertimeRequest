using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestFE.Controllers
{
    public class ApprovalRequestController : Controller
    {
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;


            ViewBag.sessionRole = tokenS.Claims.First(claim => claim.Type == "role").Value;
            ViewBag.sessionEmail = tokenS.Claims.First(claim => claim.Type == "Email").Value;
            ViewBag.sessionmanagerId = tokenS.Claims.First(claim => claim.Type == "managerId").Value;
            ViewBag.sessionNIP = tokenS.Claims.First(claim => claim.Type == "NIP").Value;
            if (ViewBag.sessionEmail != null)
            {
                if (ViewBag.sessionRole == "Manager")
                {
                    return View();
                }
                else if (ViewBag.sessionRole == "Finance")
                {
                    return View();
                }
                else
                    return RedirectToAction("index", "Home");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}
