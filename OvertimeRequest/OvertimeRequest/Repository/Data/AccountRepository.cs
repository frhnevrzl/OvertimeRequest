using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OvertimeRequest.Context;
using OvertimeRequest.Models;
using OvertimeRequest.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OvertimeRequest.Handler;

namespace OvertimeRequest.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, int>
    {
        private readonly MyContext conn;
        private readonly DbSet<RegisterVM> registers;
        private readonly Hashing hashing = new Hashing();
        private readonly EmailHandler sendEmail = new EmailHandler();
        public IConfiguration _configuration;
        public AccountRepository(MyContext conn, IConfiguration _configuration) : base(conn) 
        {
            this.conn = conn;
            registers = conn.Set<RegisterVM>();
            this._configuration = _configuration;
        }
        public string GenerateToken(LoginVM login)
        {
            var search = conn.Employees.SingleOrDefault(p => p.Email == login.Email);
            var searchRole = conn.AccountRoles.SingleOrDefault(p => p.AccountId == search.NIP);

            var claims = new List<Claim>
            {
                new Claim("FirstName", search.FirstName),
                new Claim("LastName", search.LastName),
                new Claim("Email", search.Email),
                new Claim("NIP", search.NIP.ToString()),
                //new Claim(ClaimTypes.Role, searchRole.Roles.RoleName)
                new Claim("role", searchRole.Role.RoleName),
                new Claim("managerId", search.ManagerId.ToString()) 

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                signingCredentials: signin, expires: DateTime.UtcNow.AddDays(1));
            var tokenwrite = new JwtSecurityTokenHandler().WriteToken(token);
            claims.Add(new Claim("TokenSecurity", tokenwrite.ToString()));
            return tokenwrite;
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
                    DepartmentId = 2,
                    ManagerId = 0,
                };
                conn.Add(employee);
                result = conn.SaveChanges();

                Account account = new Account
                {
                    AccountId = employee.NIP,
                    Password = Hashing.HashPassword(register.Password)
                };
                conn.Add(account);
                result = conn.SaveChanges();

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
        public int Login(LoginVM login)
        {
            var res = 0;
            var check = conn.Employees.FirstOrDefault(e => e.Email == login.Email);
            if (check != null && Hashing.ValidatePassword(login.Password, check.Account.Password))
            {
                res = 1;
            }
            else
                res = 0;
            return res;
        }

        public int ResetPassword(string email)
        {
            string resetCode = Guid.NewGuid().ToString();
            var getUser = conn.Employees.Where(e => e.Email == email).FirstOrDefault();
            var getAcount = conn.Accounts.Where(a => a.AccountId == getUser.NIP).FirstOrDefault();
            if (getUser == null)
            {
                return 0;
            }
            else
            {
                var password = Hashing.HashPassword(resetCode);
                getAcount.Password = password;
                var result = conn.SaveChanges();
                sendEmail.SendNotification(resetCode, email);
                return result;
            }
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
                    DepartmentId = e.DepartmentId,
                    ManagerId = e.ManagerId,
                    RoleId = ar.RoleId,
                    Password = ar.Account.Password  
                }).ToList();
            return all;
        }

        public RegisterVM GetProfileById(int nip)
        {
            var get = (
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
                    RoleId = ar.RoleId,
                    Password =  a.Password

                }).ToList();
            return get.FirstOrDefault(p => p.NIP == nip); ;

        }
        public int ChangePassword(ChangePasswordVM changepasswordVM)
        {
            Account acc = conn.Accounts.Where(a => a.Employee.NIP == int.Parse(changepasswordVM.NIP)).FirstOrDefault();
            acc.Password = Hashing.HashPassword(changepasswordVM.NewPassword);
            var result = conn.SaveChanges();
            return result;
        }
        public int DeleteProfile(int nip)
        {
            var del = conn.Employees.Find(nip);
            if (del != null)
            {
                conn.Remove(del);
                conn.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        public int UpdateProfile(UpdateProfileVM update)
        {

            Employee employee = conn.Employees.Find(update.NIP);
            employee.FirstName = update.FirstName;
            employee.LastName = update.LastName;
            employee.BirthDate = update.BirthDate;
            employee.Phone = update.Phone;
            employee.Email = update.Email;
            employee.Gender = update.Gender;
            employee.Religion = update.Religion;
            employee.DepartmentId = update.DepartmentId;
            employee.ManagerId = update.ManagerId;
            conn.Update(employee);

            Account account = conn.Accounts.Find(update.NIP);
            //account.Password = Hashing.HashPassword(register.Password.ToString()).ToString();
            conn.Update(account);

            return conn.SaveChanges();
        }

        public int updateRoles(RegisterVM register)
        {
            AccountRole accountRole = conn.AccountRoles.First(p => p.AccountId == register.NIP);
            accountRole.RoleId = register.RoleId;
            conn.Update(accountRole);
            return conn.SaveChanges();
        }
    }

}
