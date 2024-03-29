﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_M_Account")]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string Password { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }


    }
}
