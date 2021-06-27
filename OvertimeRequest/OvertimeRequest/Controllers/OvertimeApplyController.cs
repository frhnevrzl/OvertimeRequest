using Microsoft.AspNetCore.Http;
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
    public class OvertimeApplyController : BaseController<OvertimeApply, OvertimeApplyRepository, int>
    {
        public readonly OvertimeApplyRepository repo;
        public OvertimeApplyController(OvertimeApplyRepository repo) : base(repo)
        {
            this.repo = repo;
        }
        [HttpPost("AddOvertime")]
        public IActionResult AddOvertime(OvertimeFormVM overtimeFormVM)
        {
            if (ModelState.IsValid)
            {
                var data = repo.ApplyRequest(overtimeFormVM);
                if (data > 0)
                {
                    return Ok(new { status = "Request Added" });
                }
                else
                {
                    return StatusCode(500, new { status = "Internal server error" });
                }
            }
            else
            {
                return BadRequest(new { status = "Bad request", errorMessage = "Data input is not valid" });
            }
        }
        [HttpGet("GetAllRequest")]
        public ActionResult GetAllRequest()
        {
            var get = repo.GetAllRequest();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data tidak Ada");
            }
        }
    }
}
