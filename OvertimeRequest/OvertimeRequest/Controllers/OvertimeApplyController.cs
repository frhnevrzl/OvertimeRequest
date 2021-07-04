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

        [HttpPost("AddListOvertime")]
        public IActionResult AddListOvertime(List<OvertimeFormVM> overtimeFormVM)
        {
            if (ModelState.IsValid)
            {
                var data = repo.ApplyListRequest(overtimeFormVM);
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

        [HttpGet("GetRequestByNip/{nip}")]
        public ActionResult GetRequestByNip(int nip)
        {
            var get = repo.GetRequestByNip(nip);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }
        //id overtime
        [HttpGet("GetRequestById/{id}")]
        public ActionResult GetRequestById(int id)
        {
            var get = repo.GetRequestById(id);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }

        [HttpPut("Approval")]
        public IActionResult ApprovalRequest(ApprovalVM approvalVM)
        {
            if (ModelState.IsValid)
            {
                var approve = repo.ApproveRequest(approvalVM);
                if (approve > 0)
                {
                    if (approvalVM.Status == 3)
                    {
                        return Ok(new { status = "Rejected" });
                    }
                    else
                    {
                        return Ok(new { status = "Approved" });

                    }
                   
                }
                else
                {
                    return Ok(new { status = "Cannot Change Request Error" });
                }
            }
            else
            {
                return BadRequest(new { status = "Bad request", errorMessage = "Data input is not valid" });
            }
        }

        //buat Finance
        [HttpGet("GetAllRequestByStatus")]
        public ActionResult GetAllRequestByStatus([FromQuery(Name = "status")] int status)
        {
            var get = repo.GetAllRequestByStatus(status);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }

        //buat Manager
        [HttpGet("GetAllRequestByStatusAndManagerId")]
        public ActionResult GetAllRequestByStatusAndManagerId([FromQuery(Name = "status")] int status, [FromQuery(Name = "managerId")] int managerId)
        {
            var get = repo.GetAllRequestByStatusAndManagerId(status, managerId);
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }

    }
}
