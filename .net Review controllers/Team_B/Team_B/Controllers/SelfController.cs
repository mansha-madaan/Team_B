using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Team_B.DbModels;

namespace Team_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfController : ControllerBase
    {
        private employeeDBContext _context;
        private IConfiguration _config;

        public SelfController(IConfiguration config, employeeDBContext context)
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
        public IActionResult UpdateReview(int id, [FromBody] ReviewInfo reviewInfo)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            if (XReview.Status == "Initiate")
            {
                XReview.Status = "Save";
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

                return Ok("Cannot Updated");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            if (XReview.Status == "initiate")
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
