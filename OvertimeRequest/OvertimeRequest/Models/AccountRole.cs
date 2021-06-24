using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.Models
{
    [Table("TB_TR_AccountRole")]
    public class AccountRole
    {
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Account Account { get; set; }
    }
}
