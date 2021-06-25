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
        MyContext conn;
        public IConfiguration configuration { get; }
        public OvertimeApplyRepository(MyContext conn, IConfiguration configuration): base(conn) 
        {
            this.conn = conn;
            conn.Set<OvertimeApply>();
            this.configuration = configuration;
        }
        public int ApplyRequest(OvertimeFormVM overtimeFormVM)
        {
            var search = conn.Employees.Where(e => e.NIP == overtimeFormVM.NIP).FirstOrDefault();

            if (search.Account.AccountId == overtimeFormVM.AccountId)
            {
                var overtimeRequest = new OvertimeApply
                {
                    OvertimeName = overtimeFormVM.OvertimeName,
                    SubmissionDate = overtimeFormVM.SubmissionDate,
                };
                conn.Add(overtimeRequest);

                for (int i = 0; i < overtimeFormVM.ListDetail.Count; i++)
                {
                    var DetailRequest = new OvertimeApply();
                    DetailRequest.StartTime = overtimeFormVM.ListDetail[i].StartTime;
                    DetailRequest.EndTime = overtimeFormVM.ListDetail[i].EndTime;
                    DetailRequest.Task = overtimeFormVM.ListDetail[i].Task;
                    DetailRequest.AdditionalSalary = overtimeFormVM.ListDetail[i].AdditionalSalary;
                    conn.Add(DetailRequest);
                }
                conn.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
    }
}
