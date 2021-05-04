using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewManagementSystem.DbModels
{
    public class EmpLoginRequest
    {
        public int EmpId { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpPassword { get; set; }

        public ICollection<ProfileData> ProfileData { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
