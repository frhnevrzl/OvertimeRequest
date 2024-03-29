﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest.Base;
using OvertimeRequest.Handler;
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

        [EnableCors("AllowOrigin")]
        //[Authorize(Roles = "ADD2")]
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

        [HttpGet("GetProfile")]
        public ActionResult GetAllProfileByRole([FromQuery(Name = "roleId")] string roleId)
        {
            var get = repo.GetAllProfileByRole(int.Parse(roleId));
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("GetProfileById/{nip}")]
        public ActionResult GetProfileById(int nip)
        {
            var get = repo.GetProfileById(nip);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
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

        [HttpPut("ResetPassword")]
        public ActionResult ResetPassword(RegisterVM register)
        {
            var data = repo.ResetPassword(register.Email);
            if (data > 0)
            {
                return Ok(new { message = "Email has been Sent, password changed", status = "Ok" });
            }
            else
                return NotFound(new { message = "Data not exist in our database, please register first", status = 404 });
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            //var acc = repo.Get(int.Parse(changePasswordVM.NIP));
            //if (acc != null)
            //{
            //    if (Hashing.ValidatePassword(changePasswordVM.OldPassword, acc.Password))
            //    {
            //        var data = repo.ChangePassword(changePasswordVM);
            //        return Ok(data);
            //    }
            //    else
            //    {
            //        return StatusCode(404, new { status = "404", message = "Wrong password" });
            //    }
            //}
            //return NotFound();
            var acc = repo.Get(int.Parse(changePasswordVM.NIP));
            if (acc != null)
            {
                var data = repo.ChangePassword(changePasswordVM);
                return Ok(data);
            }
            return NotFound();
        }

    //[EnableCors("AllowOrigin")]
    [HttpPost("DeleteProfile/{nip}")]
        public ActionResult DeleteProfile(int nip)
        {
            var del = repo.DeleteProfile(nip);
            if (del != 0)
            {
                return Ok("Delete Success");
            }
            else
                return NotFound("No Record");
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("UpdateProfile")]
        public ActionResult UpdateProfile(UpdateProfileVM update)
        {
            var put = repo.UpdateProfile(update);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else
                return NotFound("Record Not Match");
        }

        [HttpPut("UpdateRoles")]
        public ActionResult UpdateRoles(RegisterVM register)
        {
            var put = repo.updateRoles(register);
            if (put > 0)
            {
                return Ok("Record Changed");
            }
            else
                return NotFound("Record Not Match");
        }
    }
}
