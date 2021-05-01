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
    public class ReviewerController : ControllerBase
    {
        private employeeDBContext _context;
        private IConfiguration _config;

        public ReviewerController(IConfiguration config, employeeDBContext context)
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
            var ReviewList = _context.Review.Where(r => r.RName == name && r.Status == "save");
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
        public IActionResult Put(int id, [FromBody] ReviewInfo TempReview)
        {
            Review XReview = _context.Review.FirstOrDefault(R => R.Rid == id);
            XReview.Status = "Reviewer Level";
            XReview.QaName = TempReview.QaName;
            XReview.RqEffect = TempReview.RqEffect;
            XReview.RqEffectStatus = TempReview.RqEffectStatus;
            XReview.RqLead = TempReview.RqLead;
            XReview.RqLeadStatus = TempReview.RqLeadStatus;
            XReview.RqFeed = TempReview.RqFeed;
            XReview.RqFeedStatus = TempReview.RqFeedStatus;
            XReview.RqGrowth = TempReview.RqGrowth;
            XReview.RqGrowthStatus = TempReview.RqGrowthStatus;
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
