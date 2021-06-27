using Microsoft.Extensions.Configuration;
using OvertimeRequest.Context;
using OvertimeRequest.Handler;
using OvertimeRequest.Models;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class OvertimeApplyRepository : GeneralRepository<MyContext, OvertimeApply, int>
    {
        private readonly EmailHandler sendEmail = new EmailHandler();
        private readonly MyContext conn;
        public IConfiguration configuration { get; }
        public OvertimeApplyRepository(MyContext conn, IConfiguration configuration): base(conn) 
        {
            this.conn = conn;
            conn.Set<OvertimeApply>();
            this.configuration = configuration;
        }
        //public int ApplyRequest(OvertimeFormVM overtimeFormVM)
        //{
        //    var search = conn.Employees.Where(e => e.NIP == overtimeFormVM.NIP).FirstOrDefault();

        //    if (search.Account.AccountId == overtimeFormVM.AccountId)
        //    {
        //        var overtimeRequest = new OvertimeApply
        //        {
        //            OvertimeName = overtimeFormVM.OvertimeName,
        //            SubmissionDate = overtimeFormVM.SubmissionDate,
        //            StartTime = overtimeFormVM.StartTime,
        //            EndTime = overtimeFormVM.EndTime,
        //            Task = overtimeFormVM.Task,
        //            AdditionalSalary = 250000
        //        };
        //        conn.Add(overtimeRequest);
        //        conn.SaveChanges();
        //        return 1;
        //    }
        //    else
        //        return 0;
        //}

        public IEnumerable<OvertimeFormVM> GetAllRequest()
        {
            var all = (
                from e in conn.Employees
                join a in conn.Accounts on e.NIP equals a.AccountId
                join ar in conn.AccountRoles on a.AccountId equals ar.AccountId
                join f in conn.overtimeApplyEmployees on e.NIP equals f.Employee.NIP
                select new OvertimeFormVM
                {
                    NIP = e.NIP,
                    OvertimeId = f.OvertimeApply.OvertimeId,
                    SubmissionDate = f.OvertimeApply.SubmissionDate,
                    StartTime = f.OvertimeApply.StartTime,
                    EndTime = f.OvertimeApply.EndTime,
                    Task = f.OvertimeApply.Task,
                    AdditionalSalary = f.OvertimeApply.AdditionalSalary

                }).ToList();
            return all;
        }
    }
}
