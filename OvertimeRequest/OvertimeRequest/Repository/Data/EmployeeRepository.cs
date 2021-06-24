using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee,int>
    {
        public EmployeeRepository(MyContext conn) : base(conn) { }
    }
}
