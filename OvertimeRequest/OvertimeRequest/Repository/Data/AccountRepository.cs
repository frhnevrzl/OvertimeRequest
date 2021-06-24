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

namespace OvertimeRequest.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, int>
    {
        MyContext conn;
        private readonly DbSet<RegisterVM> registers;
        public IConfiguration _configuration;
        public AccountRepository(MyContext conn, IConfiguration _configuration) : base(conn) 
        {
            this.conn = conn;
            registers = conn.Set<RegisterVM>();
            this._configuration = _configuration;
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
        public string GenerateToken(LoginVM login)
        {
            var search = conn.Employees.SingleOrDefault(p => p.Email == login.Email);
            var searchRole = conn.AccountRoles.SingleOrDefault(p => p.AccountId == search.NIP);


            var claims = new List<Claim>
            {
                new Claim("Email", search.Email),
                //new Claim(ClaimTypes.Role, searchRole.Roles.RoleName)
                new Claim("role", searchRole.Role.RoleName)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                signingCredentials: signin, expires: DateTime.UtcNow.AddDays(1));
            var tokenwrite = new JwtSecurityTokenHandler().WriteToken(token);
            claims.Add(new Claim("TokenSecurity", tokenwrite.ToString()));
            return tokenwrite;
        }
    }

}
