using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class OvertimeRequest
    {
        public int NIP { get; set; }
        public string Email { get; set; }
        public int AccountId { get; set; }
        public int Status { get; set; }
        public int OvertimeApplyId { get; set; }
        public int RoleId { get; set; }
    }
}
