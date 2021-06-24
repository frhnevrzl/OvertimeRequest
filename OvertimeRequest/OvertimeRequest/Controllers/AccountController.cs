﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest.Base;
using OvertimeRequest.Models;
using OvertimeRequest.Repository.Data;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, int>
    {
        AccountRepository repo;
        public AccountController(AccountRepository account) : base(account)
        {
            this.repo = account;
        }

        [HttpPost("{Register}")]
        public ActionResult Register(RegisterVM register)
        {
            var reg = repo.Register(register);
            if (reg > 0)
            {
                return Ok("Data Inserted");
            }
            else
                return BadRequest("Email Duplicate, Try New Email");
        }
        [HttpGet("GetAllProfile")]
        public ActionResult GetAllProfile()
        {
            var get = repo.GetAllProfile();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }

        [HttpPost("Login")]
        //[Route("Login")]
        public ActionResult Login(LoginVM loginvm)
        {
            var login = repo.Login(loginvm);

            if (login == 404)
            {
                return BadRequest("Email Belum Terdaftar");
            }
            else if (login == 401)
            {
                return BadRequest("Password Salah");
            }
            else if (login == 1)
            {
                return Ok(new JWTokenVM
                {
                    Token = repo.GenerateToken(loginvm),
                    Message = "Login Sukses"
                });
            }
            else
                return BadRequest("Gagal Login");
        }


    }
}
