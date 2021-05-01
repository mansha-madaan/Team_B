using System;
using System.Collections.Generic;

namespace Team_B.DbModels
{
    public partial class EmpLogin
    {
        public int EmpId { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpPassword { get; set; }

        public ICollection<ProfileData> ProfileData { get; set; }
    }
}
