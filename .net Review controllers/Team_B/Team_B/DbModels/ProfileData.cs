using System;
using System.Collections.Generic;

namespace Team_B.DbModels
{
    public partial class ProfileData
    {
        public int? EmpId { get; set; }
        public int Pid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public string Role { get; set; }
        public string TotalExp { get; set; }
        public DateTime? DateJoin { get; set; }
        public string Skills { get; set; }

        public EmpLogin Emp { get; set; }
    }
}
