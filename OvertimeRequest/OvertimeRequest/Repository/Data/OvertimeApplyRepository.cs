using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class OvertimeApplyRepository : GeneralRepository<MyContext, OvertimeApply, int>
    {
        public OvertimeApplyRepository(MyContext conn): base(conn) { }
    }
}
