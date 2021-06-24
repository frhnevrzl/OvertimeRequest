using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_OvertimeApply")]
    public class OvertimeApply
    {
        [Key]
        public int OvertimeId { get; set; }
        public string OvertimeName { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual ICollection<OvertimeApplyEmployee> OvertimeApplyEmployees { get; set; }


    }
}
