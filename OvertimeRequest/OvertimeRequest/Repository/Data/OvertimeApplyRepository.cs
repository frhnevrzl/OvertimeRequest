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
        public int ApplyRequest(OvertimeFormVM overtimeFormVM)
        {
            var overtimeApply = new OvertimeApply
            {
                OvertimeName = overtimeFormVM.OvertimeName,
                SubmissionDate = overtimeFormVM.SubmissionDate,
                StartTime = overtimeFormVM.StartTime,
                EndTime = overtimeFormVM.EndTime,
                Task = overtimeFormVM.Task,
                AdditionalSalary = 100000
            };
            conn.Add(overtimeApply);
            conn.SaveChanges();
            var overtimeApplyEmployee = new OvertimeApplyEmployee
            {
                NIP = overtimeFormVM.NIP,
                OvertimeApplyId = overtimeApply.OvertimeId,
                Status = StatusRequest.Waiting
            };
            conn.Add(overtimeApplyEmployee);
            var result = conn.SaveChanges();
            return result;
        }

        public IEnumerable<OvertimeFormVM> GetAllRequest()
        {
            var all = (
                from e in conn.Employees
                join f in conn.overtimeApplyEmployees on e.NIP equals f.Employee.NIP
                join o in conn.OvertimeApplies on f.OvertimeApplyId equals o.OvertimeId
                select new OvertimeFormVM
                {
                    NIP = f.NIP,
                    OvertimeId = f.OvertimeApplyId,
                    OvertimeName = o.OvertimeName,
                    SubmissionDate = o.SubmissionDate,
                    StartTime = o.StartTime,
                    EndTime = o.EndTime,
                    Task = o.Task,
                    AdditionalSalary = o.AdditionalSalary,
                    Status = f.Status
                }).ToList();
            return all;
        }
    }
}
