using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_TR_OvertimeApplyEmployee")]
    public class OvertimeApplyEmployee
    {
        [Key]
        public int OvertimeEmployeeId { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Task { get; set; }
        public int AdditionalSalary { get; set; }

    }
}
