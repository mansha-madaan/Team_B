using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReviewManagementSystem.DbModels;

namespace ReviewManagementSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private EmployeeDBContext _context;
        private IConfiguration _config;

        public AdminController(IConfiguration config, EmployeeDBContext context)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Admin
        [HttpGet]
        public IActionResult AdminGet()
        {
            var reviewList = _context.Review.ToList();
            return Ok(reviewList);
        }

        /*  // GET: api/Admin/5
          [HttpGet("{id}", Name = "Get")]
          public string Get(int id)
          {
              return "value";
          }*/

        // POST: api/Admin
        [HttpPost]
        public ActionResult InitiateReview(ReviewRequest reviewRequest)
        {
            reviewRequest.Rstatus = "Initiate";

            var empList = _context.EmpLogin.ToList();

            foreach(var emp in empList)
            {
                Review XReview = new Review();
                XReview.EmpId = emp.EmpId;
                XReview.Rstatus = reviewRequest.Rstatus;
                XReview.ReviewName = reviewRequest.ReviewName;
                XReview.RName = reviewRequest.RName;
                XReview.QaName = reviewRequest.QaName;
                XReview.TargetDate = reviewRequest.TargetDate;
                XReview.ReviewCycle = reviewRequest.ReviewCycle;
                XReview.PromotionCycle = reviewRequest.PromotionCycle;
                XReview.SelfEffect = " ";
                XReview.SelfEffectStatus = " ";
                XReview.SelfLead = " ";
                XReview.SelfLeadStatus = " ";
                XReview.SelfFeed = " ";
                XReview.SelfFeedStatus = " ";
                XReview.SelfGrowth = " ";
                XReview.SelfGrowthStatus = " ";
                _context.Review.Add(XReview);
                _context.SaveChanges();

            }
            return Ok("Review Initiated");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, [FromBody] ReviewRequest reviewInfo)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            if (XReview.Rstatus == "Initiate")
            {
                XReview.Rstatus = "Save";
                XReview.ReviewName = reviewInfo.ReviewName;
                XReview.RName = reviewInfo.RName;
                XReview.TargetDate = reviewInfo.TargetDate;
                XReview.ReviewCycle = reviewInfo.ReviewCycle;
                XReview.PromotionCycle = reviewInfo.PromotionCycle;
                XReview.SelfEffect = reviewInfo.SelfEffect;
                XReview.SelfEffectStatus = reviewInfo.SelfEffectStatus;
                XReview.SelfLead = reviewInfo.SelfLead;
                XReview.SelfLeadStatus = reviewInfo.SelfLeadStatus;
                XReview.SelfFeed = reviewInfo.SelfFeed;
                XReview.SelfFeedStatus = reviewInfo.SelfFeedStatus;
                XReview.SelfGrowth = reviewInfo.SelfGrowth;
                XReview.SelfGrowthStatus = reviewInfo.SelfGrowthStatus;
                _context.Review.Update(XReview);
                _context.SaveChanges();
                return Ok("Updated new review ");
            }
            else
            {

                return Ok("Cannot Update");
            }
        }
    }
}