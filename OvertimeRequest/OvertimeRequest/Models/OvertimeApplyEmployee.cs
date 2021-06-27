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
        public StatusRequest Status { get; set; }
        public virtual Employee Employee { get; set; }
        public int NIP { get; set; }
        public virtual OvertimeApply OvertimeApply { get; set; }
        public int OvertimeApplyId { get; set; }

    }
    public enum StatusRequest
    {

        [Display(Name = "Waiting For Approval")]
        Waiting = 0,
        [Display(Name = "Request Approved By Manager")]
        ApproveByManager= 1,
        [Display(Name = "Request Approved By Finance Dept")]
        ApproveByFinance = 2,
        [Display(Name = "Request Rejected")]
        Reject = 3
    }
}
