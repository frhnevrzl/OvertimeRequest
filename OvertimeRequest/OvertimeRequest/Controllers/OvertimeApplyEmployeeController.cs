using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvertimeRequest.Base;
using OvertimeRequest.Models;
using OvertimeRequest.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeApplyEmployeeController : BaseController<OvertimeApplyEmployee, OvertimeApplyEmployeeRepository, int>
    {
        public OvertimeApplyEmployeeController(OvertimeApplyEmployeeRepository overtimeApplyemployee) : base(overtimeApplyemployee)
        {
        }
    }
}
