﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequestFE.Controllers
{
    public class RequestOvertimeFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
