using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class OvertimeApplyEmployeeRepository:GeneralRepository<MyContext, OvertimeApplyEmployee, int>
    {
        public OvertimeApplyEmployeeRepository(MyContext conn) : base(conn) { }
    }
}
