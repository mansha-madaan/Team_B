using System;
using System.Collections.Generic;

namespace ReviewManagementSystem.DbModels
{
    public partial class ProfileData
    {
        public int Pid { get; set; }
        public int? EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Plocation { get; set; }
        public string Prole { get; set; }
        public string TotalExp { get; set; }
        public DateTime? DateJoin { get; set; }
        public string Skills { get; set; }
        public string R_Name { get; set; }
        public string QA_Name { get; set; }
        public string Promotion_Cycle { get; set; }

        public EmpLogin Emp { get; set; }
    }
}
