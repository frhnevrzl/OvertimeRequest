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
        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        private static bool ValidatePassword(string password, string correcthash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correcthash);
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
                    Password = HashPassword(register.Password)
                };
                conn.Add(account);
                result = conn.SaveChanges();

                //Department department = new Department
                //{
                //    DepartmentId = register.DepartmentId
                //};
                //conn.Add(department);
                //result = conn.SaveChanges();

                AccountRole accountRole = new AccountRole
                {
                    AccountId = account.AccountId,
                    RoleId = 3
                };
                conn.Add(accountRole);
                result = conn.SaveChanges();
            }
            return result;
        }
        public IEnumerable<RegisterVM> GetAllProfile()
        {
            var all = (
                from e in conn.Employees
                join a in conn.Accounts on e.NIP equals a.AccountId
                join ar in conn.AccountRoles on a.AccountId equals ar.AccountId
                select new RegisterVM
                {
                    NIP = e.NIP,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    BirthDate = e.BirthDate,
                    Gender = e.Gender,
                    Religion = e.Religion,
                    Salary = e.Salary,
                    Email = e.Email,
                    Phone = e.Phone,
                    ManagerId = e.ManagerId,
                    RoleId = ar.RoleId
                   
                }).ToList();
            return all;
            
        }
        public int Login(LoginVM login)
        {
            var res = 0;
            var check = conn.Employees.FirstOrDefault(e => e.Email == login.Email);
            if (check != null && ValidatePassword(login.Password, check.Account.Password))
            {
                res = 1;
            }
            else
                res = 0;
            return res;
        }
    }

}
