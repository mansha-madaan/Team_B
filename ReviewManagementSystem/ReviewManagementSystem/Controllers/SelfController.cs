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
    public class SelfController : ControllerBase
    {
        private EmployeeDBContext _context;
        private IConfiguration _config;

        public SelfController(IConfiguration config, EmployeeDBContext context)
        {
            _context = context;
            _config = config;
        }
        // GET: api/Self
        [HttpGet]
        public IActionResult ListOfAllReviews()
        {
            var reviewList = _context.Review.ToList();
            return Ok(reviewList);
        }

        // GET: api/Self/5
        [HttpGet("{id}")]
        public IActionResult ListById(int id)
        {
            var XReview = _context.Review.Where(r => r.EmpId == id);

            return Ok(XReview);
        }



        // PUT: api/Self/5
        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, [FromBody] ReviewRequest reviewInfo)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            if (XReview.Rstatus == "Initiate")
            {
                XReview.Rstatus = "Save";
                XReview.ReviewName = reviewInfo.ReviewName;
                XReview.RName = reviewInfo.RName;
                XReview.QaName = reviewInfo.QaName;
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

                return Ok("Cannot Updated");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            if (XReview.Rstatus == "initiate")
            {
                _context.Remove(XReview);
                _context.SaveChanges();
                return Ok("Review Deleted");
            }
            else
            {
                return Ok("Review cannot be deleted");
            }
        }
    }
}