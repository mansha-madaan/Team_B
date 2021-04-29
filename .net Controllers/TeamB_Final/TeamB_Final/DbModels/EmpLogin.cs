using System;
using System.Collections.Generic;

namespace TeamB_Final.DbModels
{
    public partial class EmpLogin
    {
        public EmpLogin()
        {
            ProfileData = new HashSet<ProfileData>();
            Review = new HashSet<Review>();
        }

        public int EmpId { get; set; }
        public string EmpEmailId { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<ProfileData> ProfileData { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
