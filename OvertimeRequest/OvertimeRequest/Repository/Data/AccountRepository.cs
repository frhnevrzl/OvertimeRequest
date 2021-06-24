using OvertimeRequest.Context;
using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, int>
    {
        public AccountRepository(MyContext conn) : base(conn) { }
    }
}
