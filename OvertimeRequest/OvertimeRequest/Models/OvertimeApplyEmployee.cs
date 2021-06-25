﻿using System;
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
        public virtual Employee Employee { get; set; }
        public virtual OvertimeApply OvertimeApply { get; set; }

    }
}
