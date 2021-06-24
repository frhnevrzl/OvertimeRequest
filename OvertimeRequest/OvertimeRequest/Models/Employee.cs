using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Employee")]
    public class Employee
    {
        [Key]
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
        public virtual Department Department { get; set; }
        public virtual ICollection<OvertimeApplyEmployee> OvertimeApplyEmployees { get; set; }


    }
}
