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
        public int ApplyRequest(OvertimeFormVM overtimeFormVM)
        {
            var overtimeApply = new OvertimeApply
            {
                OvertimeName = overtimeFormVM.OvertimeName,
                SubmissionDate = overtimeFormVM.SubmissionDate,
                StartTime = overtimeFormVM.StartTime,
                EndTime = overtimeFormVM.EndTime,
                Task = overtimeFormVM.Task,
                AdditionalSalary = overtimeFormVM.AdditionalSalary
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

        public int ApplyListRequest(List<OvertimeFormVM> overtimeFormVM)
        {
            var result = 0;
            if(overtimeFormVM.Count == 0)
            {
                return 0;
            }
            foreach (var item in overtimeFormVM)
            {
                var overtimeApply = new OvertimeApply
                {
                    OvertimeName = item.OvertimeName,
                    SubmissionDate = item.SubmissionDate,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    Task = item.Task,
                    AdditionalSalary = item.AdditionalSalary
                };
                conn.Add(overtimeApply);
                conn.SaveChanges();
                var overtimeApplyEmployee = new OvertimeApplyEmployee
                {
                    NIP = item.NIP,
                    OvertimeApplyId = overtimeApply.OvertimeId,
                    Status = StatusRequest.Waiting
                };
                conn.Add(overtimeApplyEmployee);
                result = conn.SaveChanges();
            }
            return result;
        }

        public IEnumerable<OvertimeFormVM> GetAllRequest()
        {
            var all = (
                from e in conn.Employees
                join f in conn.overtimeApplyEmployees on e.NIP equals f.NIP
                join o in conn.OvertimeApplies on f.OvertimeApplyId equals o.OvertimeId
                select new OvertimeFormVM
                {
                    OvertimeId = f.OvertimeApply.OvertimeId,
                    OvertimeName = f.OvertimeApply.OvertimeName,
                    SubmissionDate = f.OvertimeApply.SubmissionDate,
                    NIP = f.NIP,
                    StartTime = f.OvertimeApply.StartTime,
                    EndTime = f.OvertimeApply.EndTime,
                    Task = f.OvertimeApply.Task,
                    AdditionalSalary = f.OvertimeApply.AdditionalSalary,
                    Status = f.Status

                }).ToList();
            return all;
        }
        public IEnumerable<OvertimeFormVM> GetRequestById(int id)
        {
            var all = (
                from e in conn.Employees
                join f in conn.overtimeApplyEmployees on e.NIP equals f.NIP
                join o in conn.OvertimeApplies on f.OvertimeApplyId equals o.OvertimeId
                where f.OvertimeEmployeeId == id
                select new OvertimeFormVM
                {
                    AccountId = e.NIP,
                    OvertimeId = f.OvertimeApply.OvertimeId,
                    OvertimeName = f.OvertimeApply.OvertimeName,
                    SubmissionDate = f.OvertimeApply.SubmissionDate,
                    NIP = f.NIP,
                    StartTime = f.OvertimeApply.StartTime,
                    EndTime = f.OvertimeApply.EndTime,
                    Task = f.OvertimeApply.Task,
                    AdditionalSalary = f.OvertimeApply.AdditionalSalary,
                    Status = f.Status

                }).ToList();
            return all;
        }

        public IEnumerable<OvertimeFormVM> GetRequestByNip(int nip)
        {
            var all = (
                from e in conn.Employees
                join f in conn.overtimeApplyEmployees on e.NIP equals f.NIP
                join o in conn.OvertimeApplies on f.OvertimeApplyId equals o.OvertimeId
                where e.NIP == nip
                select new OvertimeFormVM
                {
                    AccountId = e.NIP,
                    OvertimeId = f.OvertimeApply.OvertimeId,
                    OvertimeName = f.OvertimeApply.OvertimeName,
                    SubmissionDate = f.OvertimeApply.SubmissionDate,
                    NIP = f.NIP,
                    StartTime = f.OvertimeApply.StartTime,
                    EndTime = f.OvertimeApply.EndTime,
                    Task = f.OvertimeApply.Task,
                    AdditionalSalary = f.OvertimeApply.AdditionalSalary,
                    Status = f.Status

                }).ToList();
            return all;
        }
        public IEnumerable<OvertimeFormVM> GetAllRequestByStatus(int status)
        {
            var request = StatusRequest.Waiting;
            if(status == 1)
            {
                request = StatusRequest.ApproveByManager;
            }
            else if (status == 2)
            {
                request = StatusRequest.ApproveByFinance;
            }
            else if (status == 3)
            {
                request = StatusRequest.Reject;
            }
            var all = (
                from e in conn.Employees
                join f in conn.overtimeApplyEmployees on e.NIP equals f.NIP
                join o in conn.OvertimeApplies on f.OvertimeApplyId equals o.OvertimeId
                where f.Status == request
                select new OvertimeFormVM
                {
                    AccountId = e.NIP,
                    OvertimeId = f.OvertimeApply.OvertimeId,
                    OvertimeName = f.OvertimeApply.OvertimeName,
                    SubmissionDate = f.OvertimeApply.SubmissionDate,
                    NIP = f.NIP,
                    StartTime = f.OvertimeApply.StartTime,
                    EndTime = f.OvertimeApply.EndTime,
                    Task = f.OvertimeApply.Task,
                    AdditionalSalary = f.OvertimeApply.AdditionalSalary,
                    Status = f.Status

                }).ToList();
            return all;
        }

        public int ListApproveRequest(List<ApprovalVM> approvalVM)
        {
            if (approvalVM.Count == 0)
            {
                return 0;
            }
            foreach (var item in approvalVM)
            {
                OvertimeApplyEmployee overtimeApplyEmployee = conn.overtimeApplyEmployees.Find(item.OvertimeApplyId);
                if (overtimeApplyEmployee == null)
                {
                    return 0;
                }
                if (item.Status == 1)
                {
                    overtimeApplyEmployee.Status = StatusRequest.ApproveByManager;
                }
                else if (item.Status == 2)
                {
                    overtimeApplyEmployee.Status = StatusRequest.ApproveByFinance;
                }
                else if (item.Status == 3)
                {
                    overtimeApplyEmployee.Status = StatusRequest.Reject;
                }
                conn.Update(overtimeApplyEmployee);
                conn.SaveChanges();
            }
            return 1;
        }

        public int ApproveRequest(ApprovalVM approvalVM)
        {
            OvertimeApplyEmployee overtimeApplyEmployee = conn.overtimeApplyEmployees.Find(approvalVM.OvertimeApplyId);
            if (overtimeApplyEmployee == null)
            {
                return 0;
            }
            if (approvalVM.Status == 1)
            {
                overtimeApplyEmployee.Status = StatusRequest.ApproveByManager;
            }
            else if (approvalVM.Status == 2)
            {
                overtimeApplyEmployee.Status = StatusRequest.ApproveByFinance;
            }
            else if (approvalVM.Status == 3)
            {
                overtimeApplyEmployee.Status = StatusRequest.Reject;
            }
            conn.Update(overtimeApplyEmployee);
            conn.SaveChanges();
            return 1;
        }
    }
}
