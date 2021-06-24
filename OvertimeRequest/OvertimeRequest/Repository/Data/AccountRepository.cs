using Microsoft.EntityFrameworkCore;
using OvertimeRequest.Context;
using OvertimeRequest.Models;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, int>
    {
        MyContext conn;
        private readonly DbSet<RegisterVM> registers;
        public AccountRepository(MyContext conn) : base(conn) 
        {
            this.conn = conn;
            registers = conn.Set<RegisterVM>();
        }

        public int Register(RegisterVM register)
        {
            var result = 0;
            var check = conn.Employees.FirstOrDefault(p => p.Email == register.Email);
            if (check == null)
            {
                Employee employee = new Employee
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    BirthDate = register.BirthDate,
                    Gender = register.Gender,
                    Religion = register.Religion,
                    Salary = register.Salary,
                    Email = register.Email,
                    Phone = register.Phone,
                    ManagerId = register.ManagerId,
                };
                conn.Add(employee);
                result = conn.SaveChanges();

                Account account = new Account
                {
                    AccountId = employee.NIP,
                    Password = register.Password
                };
                conn.Add(account);
                result = conn.SaveChanges();

                //Department department = new Department
                //{
                //    DepartmentId = register.DepartmentId
                //};
                //conn.Add(department);
                //result = conn.SaveChanges();

                Role role = new Role
                {
                    RoleId = register.RoleId
                };
                conn.Add(role);
                return result = conn.SaveChanges();
            }
            return result;
        }
    }
}
