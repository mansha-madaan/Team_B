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
    public class ReviewerController : ControllerBase
    {
        private EmployeeDBContext _context;
        private IConfiguration _config;

        public ReviewerController(IConfiguration config, EmployeeDBContext context)
        {
            _context = context;
            _config = config;
        }


        // GET: api/Reviewer
        /* [HttpGet]
         public IActionResult ListOfAllReviews()
         {
             var reviewList = _context.Review.ToList();
             return Ok(reviewList);
         }*/

        // GET: api/Reviewer/5
        [HttpGet("{id}")]
        public IActionResult ReviewerGet(int id)
        {
            
            var XProfile = _context.ProfileData.FirstOrDefault(R => R.EmpId == id);       
            var name = XProfile.FirstName;
            var ReviewList = _context.Review.Where(r => r.RName == name && r.Rstatus == "save");
            if (ReviewList == null)
                return Ok("no data found");
            return Ok(ReviewList);
        }

        // POST: api/Reviewer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Reviewer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReviewRequest reviewRequest)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            XReview.Rstatus = "Reviewer Level";
            XReview.QaName = reviewRequest.QaName;
            XReview.RqEffect = reviewRequest.RqEffect;
            XReview.RqEffectStatus = reviewRequest.RqEffectStatus;
            XReview.RqLead = reviewRequest.RqLead;
            XReview.RqLeadStatus = reviewRequest.RqLeadStatus;
            XReview.RqFeed = reviewRequest.RqFeed;
            XReview.RqFeedStatus = reviewRequest.RqFeedStatus;
            XReview.RqGrowth = reviewRequest.RqGrowth;
            XReview.RqGrowthStatus = reviewRequest.RqGrowthStatus;
            _context.Review.Update(XReview);
            _context.SaveChanges();
            return Ok(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}