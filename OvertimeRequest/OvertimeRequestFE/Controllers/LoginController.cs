using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest.Models;
using OvertimeRequest.ViewModels;
using OvertimeRequestFE.Base;
using OvertimeRequestFE.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestFE.Controllers
{
    public class LoginController : BaseController<Account, LoginRepository, int>
    {
        LoginRepository repository;
        public LoginController(LoginRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM loginVM)
        {
            var jwToken = await repository.Auth(loginVM);
            if (jwToken == null)
            {
                return RedirectToAction("login");
            }
            HttpContext.Session.SetString("JWToken", jwToken.Token);
            return RedirectToAction("index", "home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Login");
        }
        //for
    }
}
