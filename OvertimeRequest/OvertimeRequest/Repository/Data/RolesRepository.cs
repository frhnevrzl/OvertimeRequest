using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class RolesRepository : GeneralRepository<MyContext,Role, int>
    {
        public RolesRepository(MyContext conn) : base(conn) { }
    }
}
