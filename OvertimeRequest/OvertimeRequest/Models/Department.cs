using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLoc { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
