﻿using OvertimeRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OvertimeRequest.ViewModels
{
    public class OvertimeFormVM
    {
        public int OvertimeId { get; set; }
        public string OvertimeName { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int NIP { get; set; }
        public string Email { get; set; }
        public int AccountId { get; set; }
        //public int RoleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Task { get; set; }
        public int Difference { get; set; }
        public StatusRequest Status { get; set; }

    }
}
