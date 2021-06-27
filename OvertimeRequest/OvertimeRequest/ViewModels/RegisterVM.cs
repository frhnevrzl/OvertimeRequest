using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class RegisterVM
    {
        public int NIP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ManagerId { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
    }
}
