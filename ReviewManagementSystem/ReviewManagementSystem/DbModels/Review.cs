using System;
using System.Collections.Generic;

namespace ReviewManagementSystem.DbModels
{
    public partial class Review
    {
        public int Rid { get; set; }
        public int? EmpId { get; set; }
        public string ReviewName { get; set; }
        public string RName { get; set; }
        public string QaName { get; set; }
        public DateTime? TargetDate { get; set; }
        public string Rstatus { get; set; }
        public string ReviewCycle { get; set; }
        public string PromotionCycle { get; set; }
        public string SelfEffect { get; set; }
        public string SelfEffectStatus { get; set; }
        public string SelfLead { get; set; }
        public string SelfLeadStatus { get; set; }
        public string SelfFeed { get; set; }
        public string SelfFeedStatus { get; set; }
        public string SelfGrowth { get; set; }
        public string SelfGrowthStatus { get; set; }
        public string RqEffect { get; set; }
        public string RqEffectStatus { get; set; }
        public string RqLead { get; set; }
        public string RqLeadStatus { get; set; }
        public string RqFeed { get; set; }
        public string RqFeedStatus { get; set; }
        public string RqGrowth { get; set; }
        public string RqGrowthStatus { get; set; }

        public EmpLogin Emp { get; set; }
    }
}
